using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Api.Data.Models;
using Api.Data.Models.ViewModels;
using Api.Data.Repositories.Abstract;
using Api.Data.Repositories;

namespace Api.Controllers;

[ApiController]
[Route("ogrenci")]
[Authorize]
public class StudentController : ControllerBase
{


    private readonly ILogger<StudentController> logger;
    private readonly IRepository<OGRENCI> ogrenciRepo;
    private readonly IRepository<KIMLIK> kimlikRepo;
    private readonly IRepository<ILETISIM> iletisimRepo;
    private readonly IRepository<MUFREDAT> mufredatRepo;

    public StudentController(ILogger<StudentController> _logger,
        IRepository<OGRENCI> _ogrenciRepo,
        IRepository<KIMLIK> _kimlikRepo,
        IRepository<ILETISIM> _iletisimRepo,
        IRepository<MUFREDAT> _mufredatRepo
        )
    {
        logger = _logger;
        ogrenciRepo = _ogrenciRepo;
        kimlikRepo = _kimlikRepo;
        iletisimRepo = _iletisimRepo;
        mufredatRepo = _mufredatRepo;
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
    [Authorize]
    public OgrenciViewModel GetById(int id)
    {
        var ogr = ogrenciRepo.Get(ogr => ogr.ID == id);
        var kimlik = kimlikRepo.Get(kml => kml.ID == ogr.KIMLIK_ID);
        var iletisim = iletisimRepo.Get(ilt => ilt.ID == kimlik.ILETISIM_ID);

        var model = new OgrenciViewModel();
        model.ILETISIM = iletisim;
        model.KIMLIK = kimlik;
        model.OGRENCI = ogr;

        return model;
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

}

