﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Api.Data.Models.ViewModels;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Api.Data;
using Microsoft.EntityFrameworkCore;
using Api.Data.Models;
using Api.Data.Models.Enums;
namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{


    private readonly ILogger<AuthController> _logger;
    private readonly IConfiguration _configuration;
    private readonly AppDbContext _context;

    public AuthController(ILogger<AuthController> logger, IConfiguration configuration, AppDbContext context)
    {
        _logger = logger;
        _configuration = configuration;
        _context = context;
    }

    [AllowAnonymous]
    [HttpPost("giris")]
    public IActionResult Login([FromBody] LoginViewModel model)
    {
        List<string> roles;
        KULLANICI user;

        if (IsValidUser(model, out user, out roles))
        {
            var token = GenerateJwtToken(user, roles);
            if (user.TUR == KULLANICI_TIPI.USER)
            {
                //Öğrenci id getir
                var ogr = _context.OGRENCILER.Where(o => o.KIMLIKID == user.KIMLIKID)
                                             .Select(o => new
                                             {
                                                 Id = o.ID,
                                                 Mufredat_Id = o.MUFREDATID
                                             })
                                             .FirstOrDefault();
                return Ok(new { token, userType = user.TUR, userId = user.ID, OgrenciId = ogr.Id, MufredatId = ogr.Mufredat_Id });
            }

            return Ok(new { token, userType = user.TUR, userId = user.ID });
        }

        return Unauthorized("Invalid credentials");
    }
    [AllowAnonymous]
    [HttpGet("info")]
    public IActionResult Info()
    {
        try
        {
            var user = HttpContext.User;

            var currentUserIdClaim = HttpContext.User.FindFirst(ClaimTypes.GivenName);
            if (currentUserIdClaim != null && int.TryParse(currentUserIdClaim.Value, out int currentUserId))
            {
                var kullanici = _context.KULLANICILAR.Where(k => k.ID == currentUserId)
                    .Include(k => k.KIMLIK)
                    .ThenInclude(p => p.ILETISIM)
                    .FirstOrDefault();

                if (kullanici == null) return NotFound();

                KullaniciBilgiModel model = new KullaniciBilgiModel();
                model.Kullanici_Adi = kullanici.KULLANICI_ADI;
                model.AdSoyad = kullanici.KIMLIK.AD + " " + kullanici.KIMLIK.SOYAD;

                model.Adres = kullanici.KIMLIK.ILETISIM.ADRES;
                model.Il = kullanici.KIMLIK.ILETISIM.IL;
                model.Ilce = kullanici.KIMLIK.ILETISIM.ILCE;
                model.Email = kullanici.KIMLIK.ILETISIM.EMAIL;
                model.Telefon = kullanici.KIMLIK.ILETISIM.GSM;

                model.TCKN = kullanici.KIMLIK.TC_NO;
                model.DogumYeri = kullanici.KIMLIK.DOGUM_YERI;
                model.DogumTarihi = kullanici.KIMLIK.DOGUM_TARIHI;

                if (kullanici.TUR == KULLANICI_TIPI.USER)
                {
                    var ogr = _context.OGRENCILER.Where(o => o.KIMLIKID == kullanici.KIMLIKID)
                                                 .Select(o => new { Id = o.ID, Mufredat_Id = o.MUFREDATID })
                                                 .FirstOrDefault();
                    model.OgrenciId = ogr.Id;
                    model.MufredatId = ogr.Mufredat_Id;
                }

                return Ok(model);
            }
        }
        catch (Exception ex)
        {
        }

        return NotFound();

    }

    private bool IsValidUser(LoginViewModel model, out KULLANICI user, out List<string> roles)
    {
        user = _context.KULLANICILAR.Where(k => k.KULLANICI_ADI == model.KULLANICI_ADI).Include(k => k.KIMLIK).ThenInclude(p => p.ILETISIM).FirstOrDefault();

        roles = new List<string>();
        if (user == null) return false;

        if (!user.VerifyPassword(model.SIFRE)) return false;

        if (user.TUR == KULLANICI_TIPI.ADMIN)
            roles.Add("admin");
        else if (user.TUR == KULLANICI_TIPI.USER)
            roles.Add("user");

        return true;
    }

    private string GenerateJwtToken(KULLANICI user, List<string> roles)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
                new Claim(JwtRegisteredClaimNames.Sub, user.KULLANICI_ADI),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.GivenName, user.ID.ToString()),
        };

        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        var issuer = _configuration["JWT:Issuer"];
        var audience = _configuration["JWT:Audience"];
        var token = new JwtSecurityToken(
            _configuration["JWT:Issuer"],
            _configuration["JWT:Audience"],
            claims,
            expires: DateTime.UtcNow.AddHours(1), // Token expiration time
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

}

