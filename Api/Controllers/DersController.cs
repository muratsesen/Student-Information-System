using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

    public DersController(ILogger<DersController> _logger,
        IRepository<DERS> _dersRepo
        )
    {
        logger = _logger;
        dersRepo = _dersRepo;
    }

    [HttpPost("yeni")]
    [Authorize(Policy = "AdminRole")]
    public DERS Post(DERS model)
    {
        return dersRepo.Add(model);
    }

    [HttpPut("degistir")]
    [Authorize(Policy = "AdminRole")]
    public DERS Put(DERS model)
    {
        return dersRepo.Update(model);
    }


    [HttpGet("dersler")]
    [Authorize(Policy = "AdminRole")]
    public IEnumerable<DERS> Get()
    {
        return dersRepo.GetList();
    }

    [HttpGet("ders/{id}")]
    [Authorize]
    public DERS GetById(int id)
    {
        return dersRepo.Get(m => m.ID == id);
    }

}

