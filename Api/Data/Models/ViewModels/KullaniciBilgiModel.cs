using System;
namespace Api.Data.Models.ViewModels
{
    public class KullaniciBilgiModel
    {
        public string Kullanici_Adi { get; set; }
        public int OgrenciId { get; set; }
        public int MufredatId { get; set; }

        public string Adres { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }

        public long TCKN { get; set; }
        public string AdSoyad { get; set; }
        public string DogumYeri { get; set; }
        public DateTime DogumTarihi { get; set; }

    }

}

