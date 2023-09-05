
using System;
namespace Api.Data.Models.ViewModels
{
    public class KullaniciIletisimModel
    {
        public int Id { get; set; }
        public string Adres { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }
        public string Email { get; set; }
        public string Gsm { get; set; }
        public int IletisimId { get; set; }

    }
}

