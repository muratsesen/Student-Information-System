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
[Route("derskayit")]
[Authorize]
public class DersKayitController : ControllerBase
{


    private readonly ILogger<DersKayitController> logger;
    private readonly IRepository<OGRENCI> ogrenciRepo;
    private readonly IRepository<KIMLIK> kimlikRepo;
    private readonly IRepository<ILETISIM> iletisimRepo;
    private readonly IRepository<MUFREDAT> mufredatRepo;
    private readonly IRepository<KULLANICI> kullanciRepo;
    private readonly IRepository<MUFREDAT_DERSLER> mdRepo;
    private readonly AppDbContext context;

    public DersKayitController(
        ILogger<DersKayitController> _logger,
        IRepository<OGRENCI> _ogrenciRepo,
        IRepository<KIMLIK> _kimlikRepo,
        IRepository<ILETISIM> _iletisimRepo,
        IRepository<KULLANICI> _kullaniciRepo,
        IRepository<MUFREDAT> _mufredatRepo,
        IRepository<MUFREDAT_DERSLER> _mdRepo,
        AppDbContext _context
        )
    {
        logger = _logger;
        ogrenciRepo = _ogrenciRepo;
        kimlikRepo = _kimlikRepo;
        iletisimRepo = _iletisimRepo;
        mufredatRepo = _mufredatRepo;
        kullanciRepo = _kullaniciRepo;
        mdRepo = _mdRepo;
        context = _context;
    }

    [HttpPost("kayit")]
    [Authorize(Policy = "UserRole")]
    public IActionResult Post(DersKayitModel model)
    {

        //ders öğrenciye tanımlı müfredatta var mı?
        //var ogrWithMufredatDers = context.OGRENCILER.Where(s => s.ID == model.OgrenciId).Include(o => o.MUFREDAT).ThenInclude(m => m.MUFREDAT_DERSLER).FirstOrDefault();

        //var ders = ogrWithMufredatDers.MUFREDAT.MUFREDAT_DERSLER.Count(s => s.DERSID == model.DersId);

        //if (ders == 0) return BadRequest("Öğrencinin müfredatında bu ders bulunmuyor!");

        bool derseKayitliMi = context.DERS_KAYIT.Any(dk => dk.OGRENCIID == model.OgrenciId && dk.DERSID == model.DersId);

        if (derseKayitliMi)
        {
            return Ok("Öğrenci derse zaten kayıtlıdır!");
        }

        var dersKayit = new DERS_KAYIT()
        {
            DERSID = model.DersId,
            OGRENCIID = model.OgrenciId,
            CREATED_DATE = DateTime.UtcNow
        };

        context.DERS_KAYIT.Add(dersKayit);
        context.SaveChanges();

        return Ok(dersKayit);
    }




    [HttpGet("dersler/{mufredat_id}")]
    [Authorize]
    public async Task<IActionResult> Get(int mufredat_id)
    {
        // var muf = await mdRepo.GetListWithIncludeAsync(m => m.MUFREDATID == 1, m => m.DERSLER);
        var mufredatDersler = context.MUFREDAT_DERSLER
                                    .Where(md => md.MUFREDATID == mufredat_id)
                                    .Select(md => md.DERS)
                                    .ToList();
        return Ok(mufredatDersler);
    }

    [HttpGet("ogrenci/{id}")]
    [Authorize(Roles = "admin,user")]
    public IActionResult GetById(int id)
    {
        var ogr = ogrenciRepo.Get(ogr => ogr.ID == id);
        var kimlik = kimlikRepo.Get(kml => kml.ID == ogr.KIMLIKID);
        var iletisim = iletisimRepo.Get(ilt => ilt.ID == kimlik.ILETISIMID);

        var model = new OgrenciViewModel();
        model.ILETISIM = iletisim;
        model.KIMLIK = kimlik;
        model.OGRENCI = ogr;

        var user = HttpContext.User;

        if (user.IsInRole("admin"))
        {
            return Ok(model);
        }

        var kullanici = GetUser(id);

        if (!IsCurrentUser(kullanici.ID))
        {
            return Unauthorized();
        }

        return Ok(model);
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

