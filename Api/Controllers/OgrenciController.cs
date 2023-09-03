using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Api.Data.Models;
using Api.Data.Models.ViewModels;
using Api.Data.Repositories.Abstract;
using Api.Data.Repositories;
using System.Security.Claims;

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

    public OgrenciController(ILogger<OgrenciController> _logger,
        IRepository<OGRENCI> _ogrenciRepo,
        IRepository<KIMLIK> _kimlikRepo,
        IRepository<ILETISIM> _iletisimRepo,
        IRepository<KULLANICI> _kullaniciRepo,
        IRepository<MUFREDAT> _mufredatRepo
        )
    {
        logger = _logger;
        ogrenciRepo = _ogrenciRepo;
        kimlikRepo = _kimlikRepo;
        iletisimRepo = _iletisimRepo;
        mufredatRepo = _mufredatRepo;
        kullanciRepo = _kullaniciRepo;
    }

    [HttpPost("yeni")]
    [Authorize(Policy = "AdminRole")]
    public StudentCreateModel Post(StudentCreateModel model)
    {
        if (model.ILETISIM != null)
        {
            iletisimRepo.Add(model.ILETISIM);
        }

        if (model.KIMLIK != null)
        {
            model.KIMLIK.ILETISIM_ID = model.ILETISIM.ID;
            kimlikRepo.Add(model.KIMLIK);
        }

        if (model.OGRENCI != null)
        {
            model.OGRENCI.KIMLIK_ID = model.KIMLIK.ID;
            ogrenciRepo.Add(model.OGRENCI);
        }

        return model;
    }

    [HttpPost("degistir")]
    [Authorize(Policy = "AdminRole")]
    public StudentCreateModel Put(StudentCreateModel model)
    {

        if (model.ILETISIM != null)
        {
            iletisimRepo.Update(model.ILETISIM);
        }

        if (model.KIMLIK != null)
        {
            kimlikRepo.Update(model.KIMLIK);
        }

        if (model.OGRENCI != null)
        {
            ogrenciRepo.Update(model.OGRENCI);
        }
        return model;
    }


    [HttpGet("ogrenciler")]
    [Authorize(Policy = "AdminRole")]
    public IEnumerable<OGRENCI> Get()
    {
        return ogrenciRepo.GetList();
    }

    [HttpGet("ogrenci/{id}")]
    [Authorize(Roles = "admin,user")]
    public IActionResult GetById(int id)
    {
        var ogr = ogrenciRepo.Get(ogr => ogr.ID == id);
        var kimlik = kimlikRepo.Get(kml => kml.ID == ogr.KIMLIK_ID);
        var iletisim = iletisimRepo.Get(ilt => ilt.ID == kimlik.ILETISIM_ID);

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
        return kullanciRepo.Get(k => k.KIMLIK_ID == ogr.KIMLIK_ID);
    }

    [HttpGet("mufredat/{ogrenci_id}")]
    [Authorize()]
    public MUFREDAT GetMufredat(int ogrenci_id)
    {
        var ogr = ogrenciRepo.Get(ogr => ogr.ID == ogrenci_id);

        if (ogr != null)
        {
            return mufredatRepo.Get(m => m.ID == ogr.MUFREDAT_ID);
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
            ogr.MUFREDAT_ID = model.MufredatId;

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
            return mufredatRepo.Get(m => m.ID == ogr.MUFREDAT_ID);
        }

        return null;
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

