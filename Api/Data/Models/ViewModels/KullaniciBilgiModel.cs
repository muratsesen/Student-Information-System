using System;
namespace Api.Data.Models.ViewModels
{
    public class KullaniciBilgiModel
    {
        public string Kullanici_Adi { get; set; }
        public int OgrenciId { get; set; }
        public int MufredatId { get; set; }
        public string AdSoyad { get; set; }
        public long TCKN { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }

    }
}

