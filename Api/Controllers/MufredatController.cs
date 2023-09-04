using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Api.Data.Models;
using Api.Data;
using Api.Data.Models.ViewModels;
using Api.Data.Repositories.Abstract;
using Api.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("mufredat")]
[Authorize]
public class MufredatController : ControllerBase
{


    private readonly ILogger<MufredatController> logger;
    private readonly IRepository<MUFREDAT> mufredatRepo;
    private readonly AppDbContext context;

    public MufredatController(ILogger<MufredatController> _logger,
        IRepository<MUFREDAT> _mufredatRepo,
        AppDbContext _context
        )
    {
        logger = _logger;
        mufredatRepo = _mufredatRepo;
        context = _context;
    }

    [HttpPost("yeni")]
    [Authorize(Policy = "AdminRole")]
    public IActionResult Post(MufredatKayitModel model)
    {
        var count = mufredatRepo.GetCount(m => m.MUFREDAT_ADI == model.Name);

        if (count > 0) return BadRequest("Müfredat ismi zaten var.");

        var mufredat = new MUFREDAT();
        mufredat.MUFREDAT_ADI = model.Name;

        mufredatRepo.Add(mufredat);

        if (model.Lessons.Count > 0)
        {
            foreach (var lessonId in model.Lessons)
            {
                context.MUFREDAT_DERSLER.Add(new MUFREDAT_DERSLER
                {
                    DERSID = lessonId,
                    MUFREDATID = mufredat.ID
                });
            }
        }
        context.SaveChanges();

        return Ok();
    }

    [HttpPut("degistir")]
    [Authorize(Policy = "AdminRole")]
    public IActionResult Put(MufredatKayitModel model)
    {

        var mufredat = mufredatRepo.Get(m => m.ID == model.Id);
        mufredat.MUFREDAT_ADI = model.Name;

        mufredatRepo.Update(mufredat);

        // Fetch the existing lessons associated with the MUFREDATID
        var existingLessons = context.MUFREDAT_DERSLER
            .Where(md => md.MUFREDATID == mufredat.ID)
            .ToList();

        // Convert the existing lessons to a HashSet for efficient comparison
        var existingLessonIds = new HashSet<int>(existingLessons.Select(md => md.DERSID));

        // Convert the new lessons to a HashSet for efficient comparison
        var newLessonIds = new HashSet<int>(model.Lessons);

        // Find lessons to be added (in newLessonIds but not in existingLessonIds)
        var lessonsToAdd = newLessonIds.Except(existingLessonIds);

        // Find lessons to be removed (in existingLessonIds but not in newLessonIds)
        var lessonsToRemove = existingLessonIds.Except(newLessonIds);

        // Add new lessons
        foreach (var lessonId in lessonsToAdd)
        {
            context.MUFREDAT_DERSLER.Add(new MUFREDAT_DERSLER
            {
                DERSID = lessonId,
                MUFREDATID = mufredat.ID
            });
        }

        // Remove lessons
        foreach (var lessonId in lessonsToRemove)
        {
            var lessonToRemove = existingLessons.FirstOrDefault(md => md.DERSID == lessonId);
            if (lessonToRemove != null)
            {
                context.MUFREDAT_DERSLER.Remove(lessonToRemove);
            }
        }

        context.SaveChanges();


        return Ok();
    }


    [HttpGet("mufredatlar")]
    [Authorize(Policy = "AdminRole")]
    public IActionResult Get()
    {
        var data = context.MUFREDATLAR.Select(m => new
        {
            Id = m.ID,
            Name = m.MUFREDAT_ADI,
        });
        return Ok(data);
    }

    [HttpGet("mufredat/{id}")]
    [Authorize]
    public IActionResult GetById(int id)
    {
        var data = context.MUFREDATLAR.Where(m => m.ID == id)
            .Select(m => new
            {
                Id = m.ID,
                Name = m.MUFREDAT_ADI,
                Lessons = m.MUFREDAT_DERSLER
            }).FirstOrDefault();


        return Ok(data);
    }

    [HttpGet("dersler/{mufredat_id}")]
    [Authorize(Policy = "AdminRole")]
    public IActionResult GetLessonList(int mufredat_id)
    {
        var data = context.MUFREDAT_DERSLER
            .Where(m => m.MUFREDATID == mufredat_id)
            .Include(m => m.DERS)
            .Select(d => new
            {
                Id = d.DERS.ID,
                Name = d.DERS.DERS_ADI,
                code = d.DERS.DERS_KODU,
                status = d.DERS.DURUM,
                credit = d.DERS.KREDI
            })
            .ToList();

        if (data == null) return NoContent();

        return Ok(data);
    }

}

