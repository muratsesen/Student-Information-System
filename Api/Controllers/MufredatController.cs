using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Api.Data.Models;
using Api.Data.Models.ViewModels;
using Api.Data.Repositories.Abstract;
using Api.Data.Repositories;

namespace Api.Controllers;

[ApiController]
[Route("mufredat")]
[Authorize]
public class MufredatController : ControllerBase
{


    private readonly ILogger<MufredatController> logger;
    private readonly IRepository<MUFREDAT> mufredatRepo;

    public MufredatController(ILogger<MufredatController> _logger,
        IRepository<MUFREDAT> _mufredatRepo
        )
    {
        logger = _logger;
        mufredatRepo = _mufredatRepo;
    }

    [HttpPost("yeni")]
    [Authorize(Policy = "AdminRole")]
    public MUFREDAT Post(MUFREDAT model)
    {
        var count = mufredatRepo.GetCount(m => m.MUFREDAT_ADI == model.MUFREDAT_ADI);

        mufredatRepo.Add(model);

        return model;
    }

    [HttpPut("degistir")]
    [Authorize(Policy = "AdminRole")]
    public MUFREDAT Put(MUFREDAT model)
    {
        return mufredatRepo.Update(model);
    }


    [HttpGet("mufredatlar")]
    [Authorize(Policy = "AdminRole")]
    public IEnumerable<MUFREDAT> Get()
    {
        return mufredatRepo.GetList();
    }

    [HttpGet("mufredat/{id}")]
    [Authorize]
    public MUFREDAT GetById(int id)
    {
        return mufredatRepo.Get(m => m.ID == id);
    }

}

