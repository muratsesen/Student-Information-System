using Api.Data;
using Api.Data.Models;
using Api.Data.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("users")]
[Authorize(Policy = "AdminRole")]
public class UserController : ControllerBase
{

    private readonly ILogger<UserController> _logger;
    private readonly AppDbContext context;

    public UserController(ILogger<UserController> logger, AppDbContext _context)
    {
        _logger = logger;
        context = _context;
    }

    [HttpGet]

    public IActionResult Get()
    {
        return Ok(context.KULLANICILAR
            .Include(u => u.KIMLIK)
            .ThenInclude(k => k.ILETISIM)
            .Select(x => new UserViewModel
            {
                Id = x.ID,
                Type = x.TUR,
                Ad = x.KIMLIK.AD,
                Soyad = x.KIMLIK.SOYAD
            })
            .ToList());
    }

    [HttpGet("{id}")]
    [Authorize(Policy = "AdminRole")]
    public IActionResult GetDetail(int id)
    {
        var kullanici = context.KULLANICILAR.Where(u => u.ID == id)
            .Include(k => k.KIMLIK).ThenInclude(k => k.ILETISIM).
            Select(x => new
            {
                Id = x.ID,
                Type = x.TUR,
                TckNo = x.KIMLIK.TC_NO,
                Ad = x.KIMLIK.AD,
                Soyad = x.KIMLIK.SOYAD,
                Adres = x.KIMLIK.ILETISIM.ADRES,
                Il = x.KIMLIK.ILETISIM.IL,
                Ilce = x.KIMLIK.ILETISIM.ILCE,
                Email = x.KIMLIK.ILETISIM.EMAIL,
                Gsm = x.KIMLIK.ILETISIM.GSM,
                DogumYeri = x.KIMLIK.DOGUM_YERI,
                DogumTarihi = x.KIMLIK.DOGUM_TARIHI,
                IletisimId = x.KIMLIK.ILETISIMID,
                KimlikId = x.KIMLIKID,
            })
            .FirstOrDefault();


        return Ok(kullanici);
    }

    [HttpPost]
    public IActionResult Post(KULLANICI user)
    {
        context.KULLANICILAR.Add(user);
        context.SaveChanges();

        return Ok(user);
    }

    [HttpPut]
    public IActionResult Put(KULLANICI user)
    {
        context.KULLANICILAR.Update(user);
        context.SaveChanges();

        return Ok(user);
    }

    [HttpDelete]
    public IActionResult Delete(KULLANICI user)
    {
        context.KULLANICILAR.Remove(user);
        context.SaveChanges();

        return Ok(user);
    }
}

