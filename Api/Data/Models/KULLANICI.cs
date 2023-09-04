using System;
using BCrypt.Net;
using System.Collections.Generic;
using Api.Data.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using Api.Data.Repositories.Abstract;


namespace Api.Data.Models;

public class KULLANICI : BaseEntity, IEntity
{
    public string KULLANICI_ADI { get; set; }
    public string SIFRE { get; set; }
    public KULLANICI_TIPI TUR { get; set; }
    public int KIMLIKID { get; set; }

    public KIMLIK KIMLIK { get; set; }

    public void SetPassword(string password)
    {
        var salt = BCrypt.Net.BCrypt.GenerateSalt(12);

        SIFRE = BCrypt.Net.BCrypt.HashPassword(password, salt);
    }

    public bool VerifyPassword(string password)
    {
        return BCrypt.Net.BCrypt.Verify(password, SIFRE);
    }

}