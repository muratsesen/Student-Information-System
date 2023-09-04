using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Api.Data;
using Api.Data.Models;
using Api.Data.Models.ViewModels;
using Api.Data.Repositories.Abstract;
using Api.Data.Repositories;

namespace Api.Controllers;

[ApiController]
[Route("DERS")]
[Authorize]
public class DersController : ControllerBase
{


    private readonly ILogger<DersController> logger;
    private readonly IRepository<DERS> dersRepo;
    private readonly AppDbContext context;

    public DersController(ILogger<DersController> _logger,
        IRepository<DERS> _dersRepo,
        AppDbContext _context
        )
    {
        logger = _logger;
        dersRepo = _dersRepo;
        context = _context;
    }

    [HttpPost("yeni")]
    [Authorize(Policy = "AdminRole")]
    public IActionResult Post(YeniDersModel model)
    {
        var ders = new DERS();

        ders.DERS_ADI = model.Name;
        ders.DERS_KODU = model.Code;
        ders.DURUM = model.Status;
        ders.KREDI = model.Credit;

        dersRepo.Add(ders);

        return Ok(ders);
    }

    [HttpPut("degistir")]
    [Authorize(Policy = "AdminRole")]
    public IActionResult Put(YeniDersModel model)
    {
        var ders = dersRepo.Get(d => d.ID == model.Id);

        if (ders == null) return BadRequest("Ders bulunamadı");

        ders.DERS_ADI = model.Name;
        ders.DERS_KODU = model.Code;
        ders.DURUM = model.Status;
        ders.KREDI = model.Credit;

        dersRepo.Update(ders);

        return Ok(ders);
    }


    [HttpGet("dersler")]
    [Authorize(Policy = "AdminRole")]
    public IActionResult Get()
    {
        var lessons = context.DERSLER.Select(d => new
        {
            Id = d.ID,
            Name = d.DERS_ADI,
            Credit = d.KREDI,
            Code = d.DERS_KODU,
            Status = d.DURUM
        }).ToList();
        return Ok(lessons);
    }

    [HttpGet("ders/{id}")]
    [Authorize]
    public IActionResult GetById(int id)
    {
        var res = dersRepo.Get(m => m.ID == id);

        return Ok(new
        {
            id = res.ID,
            name = res.DERS_ADI,
            code = res.DERS_KODU,
            credit = res.KREDI,
            status = res.DURUM
        });
    }

}

