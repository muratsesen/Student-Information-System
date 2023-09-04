using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Api.Data;
using Api.Data.Models;
using Api.Data.Models.ViewModels;
using Api.Data.Repositories.Abstract;
using Api.Data.Repositories;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;


namespace Api.Controllers;

[ApiController]
[Route("ogrenci")]
[Authorize]
public class OgrenciController : ControllerBase
{


    private readonly ILogger<OgrenciController> logger;
    private readonly IRepository<OGRENCI> ogrenciRepo;
    private readonly IRepository<KIMLIK> kimlikRepo;
    private readonly IRepository<ILETISIM> iletisimRepo;
    private readonly IRepository<MUFREDAT> mufredatRepo;
    private readonly IRepository<KULLANICI> kullanciRepo;
    private readonly AppDbContext context;

    public OgrenciController(ILogger<OgrenciController> _logger,
        IRepository<OGRENCI> _ogrenciRepo,
        IRepository<KIMLIK> _kimlikRepo,
        IRepository<ILETISIM> _iletisimRepo,
        IRepository<KULLANICI> _kullaniciRepo,
        IRepository<MUFREDAT> _mufredatRepo,
        AppDbContext _context
        )
    {
        logger = _logger;
        ogrenciRepo = _ogrenciRepo;
        kimlikRepo = _kimlikRepo;
        iletisimRepo = _iletisimRepo;
        mufredatRepo = _mufredatRepo;
        kullanciRepo = _kullaniciRepo;
        context = _context;
    }

    [HttpPost("yeni")]
    [Authorize(Policy = "AdminRole")]
    public StudentCreateModel Post(StudentCreateModel model)
    {
        var ogrenci = new OGRENCI();
        var iletisim = new ILETISIM();
        var kimlik = new KIMLIK();

        iletisim.ADRES = model.Adres;
        iletisim.EMAIL = model.Email;
        iletisim.GSM = model.Gsm;
        iletisim.IL = model.Il;
        iletisim.ILCE = model.Ilce;

        kimlik.TC_NO = model.TckNo;
        kimlik.AD = model.Ad;
        kimlik.SOYAD = model.Soyad;
        kimlik.DOGUM_TARIHI = model.DogumTarihi;
        kimlik.DOGUM_YERI = model.DogumYeri;

        //iletisim.ID = 99;
        //iletisimRepo.Add(iletisim);
        context.ILETISIMLER.Add(iletisim);
        context.SaveChanges();

        kimlik.ILETISIMID = iletisim.ID;
        kimlikRepo.Add(kimlik);

        ogrenci.KIMLIKID = kimlik.ID;
        ogrenci.MUFREDATID = model.MufredatId;

        ogrenciRepo.Add(ogrenci);


        return model;
    }

    [HttpPut("degistir")]
    [Authorize(Policy = "AdminRole")]
    public StudentCreateModel Put(StudentCreateModel model)
    {
        var ogrenci = ogrenciRepo.Get(o => o.ID == model.OgrenciId);
        var iletisim = iletisimRepo.Get(i => i.ID == model.IletisimId);
        var kimlik = kimlikRepo.Get(k => k.ID == model.KimlikId);

        iletisim.ADRES = model.Adres;
        iletisim.EMAIL = model.Email;
        iletisim.GSM = model.Gsm;
        iletisim.IL = model.Il;
        iletisim.ILCE = model.Ilce;

        kimlik.TC_NO = model.TckNo;
        kimlik.AD = model.Ad;
        kimlik.SOYAD = model.Soyad;
        kimlik.DOGUM_TARIHI = model.DogumTarihi;
        kimlik.DOGUM_YERI = model.DogumYeri;


        iletisimRepo.Update(iletisim);

        kimlikRepo.Update(kimlik);

        ogrenci.MUFREDATID = model.MufredatId;

        ogrenciRepo.Update(ogrenci);


        return model;
    }

    [HttpPut("iletisim")]
    [Authorize(Roles = "admin,user")]
    public IActionResult PutIletisim(OgrenciIletisimModel model)
    {
        var ogr = ogrenciRepo.Get(o => o.ID == model.OGRENCI_ID);

        var kimlik = kimlikRepo.Get(k => k.ID == ogr.KIMLIKID);

        var iletisim = iletisimRepo.Get(i => i.ID == kimlik.ILETISIMID);


        if (model.ILETISIM != null)
        {
            iletisim.ADRES = model.ILETISIM.ADRES;
            iletisim.EMAIL = model.ILETISIM.EMAIL;
            iletisim.GSM = model.ILETISIM.GSM;
            iletisim.IL = model.ILETISIM.IL;
            iletisim.ILCE = model.ILETISIM.ILCE;

            iletisimRepo.Update(iletisim);
            return Ok();
        }

        return NotFound();

    }

    [HttpGet("ogrenciler")]
    [Authorize(Policy = "AdminRole")]
    public IActionResult Get()
    {
        //var ogrencilListesi = ogrenciRepo.GetList();
        var ogrencilListesi = context.OGRENCILER.Include(o => o.KIMLIK).ToList();

        List<OgrenciModel> ogrenciModels = new List<OgrenciModel>();

        foreach (var ogrenci in ogrencilListesi)
        {
            ogrenciModels.Add(new OgrenciModel
            {
                Id = ogrenci.ID,
                Name = ogrenci.KIMLIK.AD + " " + ogrenci.KIMLIK.SOYAD
            });
        }

        return Ok(ogrenciModels);
    }

    [HttpGet("ogrenci/{id}")]
    [Authorize(Roles = "admin,user")]
    public IActionResult GetById(int id)
    {
        //var ogr = ogrenciRepo.Get(ogr => ogr.ID == id);
        //var kimlik = kimlikRepo.Get(kml => kml.ID == ogr.KIMLIKID);
        //var iletisim = iletisimRepo.Get(ilt => ilt.ID == kimlik.ILETISIMID);
        var ogrenci = context.OGRENCILER.Where(o => o.ID == id)
            .Include(o => o.MUFREDAT)
            .Include(o => o.KIMLIK).ThenInclude(k => k.ILETISIM)
            .Select(o => new
            {

                OgrenciId = o.ID,
                OgrenciNo = o.OGR_NO,
                Adres = o.KIMLIK.ILETISIM.ADRES,
                Il = o.KIMLIK.ILETISIM.IL,
                Ilce = o.KIMLIK.ILETISIM.ILCE,
                Email = o.KIMLIK.ILETISIM.EMAIL,
                Gsm = o.KIMLIK.ILETISIM.GSM,
                TckNo = o.KIMLIK.TC_NO,
                Ad = o.KIMLIK.AD,
                Soyad = o.KIMLIK.SOYAD,
                DogumYeri = o.KIMLIK.DOGUM_YERI,
                DogumTarihi = o.KIMLIK.DOGUM_TARIHI,
                MufredatId = o.MUFREDAT.ID,
                IletisimId = o.KIMLIK.ILETISIMID,
                KimlikId = o.KIMLIKID,
                MufredatName = o.MUFREDAT.MUFREDAT_ADI,
            })
            .FirstOrDefault();

        var user = HttpContext.User;

        if (user.IsInRole("admin"))
        {
            return Ok(ogrenci);
        }

        var kullanici = GetUser(id);

        if (!IsCurrentUser(kullanici.ID))
        {
            return Unauthorized();
        }

        return Ok(ogrenci);
    }

    [HttpGet("mufredat/{ogrenci_id}")]
    [Authorize()]
    public MUFREDAT GetMufredat(int ogrenci_id)
    {
        var ogr = ogrenciRepo.Get(ogr => ogr.ID == ogrenci_id);

        if (ogr != null)
        {
            return mufredatRepo.Get(m => m.ID == ogr.MUFREDATID);
        }

        return null;
    }

    [HttpPost("mufredat")]
    [Authorize()]
    public OGRENCI PostMufredat(OgrenciMufredatModel model)
    {
        var ogr = ogrenciRepo.Get(ogr => ogr.ID == model.OgrenciId);

        if (ogr != null)
        {
            ogr.MUFREDATID = model.MufredatId;

            ogrenciRepo.Update(ogr);

            return ogr;
        }

        return null;
    }

    [HttpPut("mufredat-degistir")]
    [Authorize(Policy = "AdminRole")]
    public MUFREDAT PutOgrenciMufredat(int ogrenci_id)
    {
        var ogr = ogrenciRepo.Get(ogr => ogr.ID == ogrenci_id);

        if (ogr != null)
        {
            return mufredatRepo.Get(m => m.ID == ogr.MUFREDATID);
        }

        return null;
    }

    [HttpGet("kayitolunan-dersler/{ogrenci_id}")]
    [Authorize]
    public IActionResult GetRegisteredLessonsOfAStudent(int ogrenci_id)
    {
        var res = context.OGRENCILER.Where(o => o.ID == ogrenci_id)
            .SelectMany(o => o.DERS_KAYITLARI)
            .Select(dk => dk.DERS
                        )
            .ToList();

        return Ok(res);
    }


    private KULLANICI GetUser(int id)
    {
        var ogr = ogrenciRepo.Get(o => o.ID == id);

        if (ogr == null)
        {
            return null;
        }
        return kullanciRepo.Get(k => k.KIMLIKID == ogr.KIMLIKID);
    }
    private bool IsCurrentUser(int studentId)
    {

        // var currentUserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var currentUserIdClaim = HttpContext.User.FindFirst(ClaimTypes.GivenName);
        if (currentUserIdClaim != null && int.TryParse(currentUserIdClaim.Value, out int currentUserId))
        {
            return currentUserId == studentId;
        }
        return false;
        //return currentUserId == studentId.ToString();
    }
}

