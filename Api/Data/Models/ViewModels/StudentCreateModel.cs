using System;
namespace Api.Data.Models.ViewModels
{
    public class StudentCreateModel
    {
        public OGRENCI OGRENCI { get; set; }
        public ILETISIM? ILETISIM { get; set; }
        public KIMLIK? KIMLIK { get; set; }
    }
}

