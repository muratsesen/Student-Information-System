using System;
using Api.Data.Models.Enums;

namespace Api.Data.Models.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public KULLANICI_TIPI Type { get; set; }
        public string Adres { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }
        public string Email { get; set; }
        public string Gsm { get; set; }

        public long TckNo { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string DogumYeri { get; set; }
        public DateTime DogumTarihi { get; set; }

        public int IletisimId { get; set; }
        public int KimlikId { get; set; }
    }
}

