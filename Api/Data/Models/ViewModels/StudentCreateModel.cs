﻿using System;
namespace Api.Data.Models.ViewModels
{
    public class StudentCreateModel
    {
        public int OgrenciId { get; set; }
        public int OgrenciNo { get; set; }
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
        public int MufredatId { get; set; }
        public int IletisimId { get; set; }
        public int KimlikId { get; set; }
    }
}

