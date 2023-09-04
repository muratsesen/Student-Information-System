using System;
using Microsoft.EntityFrameworkCore;
using Api.Data.Models;
using System.Reflection.Emit;
using Microsoft.AspNetCore.Identity;
using System.Globalization;
using Api.Data.Models.Enums;
using System.Drawing;

namespace Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);


        }

        //public DbSet<User> Users { get; set; }
        //public DbSet<Role> Roles { get; set; }
        //public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<OGRENCI> OGRENCILER { get; set; }
        public DbSet<KULLANICI> KULLANICILAR { get; set; }
        public DbSet<KIMLIK> KIMLIKLER { get; set; }
        public DbSet<ILETISIM> ILETISIMLER { get; set; }
        public DbSet<DERS> DERSLER { get; set; }
        public DbSet<DERS_KAYIT> DERS_KAYIT { get; set; }
        public DbSet<MUFREDAT> MUFREDATLAR { get; set; }
        public DbSet<MUFREDAT_DERSLER> MUFREDAT_DERSLER { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<OGRENCI>()
            //    .HasOne(o => o.MUFREDAT)
            //    .WithMany(m => m.OGRENCILER).HasForeignKey(p => p.MUFREDATID);

            //modelBuilder.Entity<MUFREDAT>()
            //    .HasMany(m => m.MUFREDAT_DERSLER)
            //    .WithOne(md => md.MUFREDAT)
            //    .HasForeignKey(md => md.MUFREDATID);

            //modelBuilder.Entity<DERS>()
            //    .HasMany(d => d.MUFREDAT_DERSLERs)
            //    .WithOne(md => md.DERS)
            //    .HasForeignKey(md => md.DERSID);

            //modelBuilder.Entity<MUFREDAT_DERSLER>()
            //    .HasOne(md => md.MUFREDAT)
            //    .WithMany(m => m.MUFREDAT_DERSLER)
            //    .HasForeignKey(md => md.MUFREDATID);

            //modelBuilder.Entity<MUFREDAT_DERSLER>()
            //    .HasOne(md => md.DERS)
            //    .WithMany(d => d.MUFREDAT_DERSLERs)
            //    .HasForeignKey(md => md.DERSID);

            //modelBuilder.Entity<KULLANICI>()
            //    .HasOne(k => k.KIMLIK)
            //    .WithOne()
            //    .HasForeignKey<KIMLIK>(k => k.ID);


            //modelBuilder.Entity<KIMLIK>()
            //    .HasOne(k => k.ILETISIM)
            //    .WithOne()
            //    .HasForeignKey<ILETISIM>(i => i.ID);

            //modelBuilder.Entity<OGRENCI>()
            //    .HasOne(o => o.KIMLIK)
            //    .WithOne()
            //    .HasForeignKey<OGRENCI>(k => k.KIMLIKID);

            //Bir öğrencinin bir derse sadece bir kere kayıt olmasını kontrol eder.
            //modelBuilder.Entity<DERS_KAYIT>()
            //            .HasAlternateKey(r => new { r.OGRID, r.DERSID })
            //            .HasName("UQ_DersKayit");

            //modelBuilder.Entity<DERS_KAYIT>()
            //    .HasOne(dk => dk.OGRENCI)
            //    .WithMany(o => o.DERS_KAYITLARI)
            //    .HasForeignKey(dk => dk.OGRID);

            //modelBuilder.Entity<DERS_KAYIT>()
            //    .HasOne(dk => dk.DERS)
            //    .WithMany(d => d.DERS_KAYITLARI)
            //    .HasForeignKey(dk => dk.DERSID);



            modelBuilder.Entity<OGRENCI>().HasData(
                new OGRENCI { ID = 1, OGR_NO = 27482379, KIMLIKID = 3, MUFREDATID = 1 },
                new OGRENCI { ID = 2, OGR_NO = 23462368, KIMLIKID = 5, MUFREDATID = 1 },
                new OGRENCI { ID = 3, OGR_NO = 34565479, KIMLIKID = 6, MUFREDATID = 2 },
                new OGRENCI { ID = 4, OGR_NO = 53456346, KIMLIKID = 2, MUFREDATID = 2 },
                new OGRENCI { ID = 5, OGR_NO = 34674575, KIMLIKID = 4, MUFREDATID = 3 }
            );
            modelBuilder.Entity<KIMLIK>().HasData(
                new KIMLIK { ID = 1, TC_NO = 45456747611, AD = "Hasan", SOYAD = "Ersoy", DOGUM_YERI = "Kayseri", DOGUM_TARIHI = CreateUtcDate("11.10.1983"), ILETISIMID = 4 },
                new KIMLIK { ID = 2, TC_NO = 67967856634, AD = "Mehmet", SOYAD = "Yılmaz", DOGUM_YERI = "Adana", DOGUM_TARIHI = CreateUtcDate("12.03.2000"), ILETISIMID = 1 },
                new KIMLIK { ID = 3, TC_NO = 72347322958, AD = "Ahmet", SOYAD = "Ünal", DOGUM_YERI = "Ankara", DOGUM_TARIHI = CreateUtcDate("14.06.2001"), ILETISIMID = 6 },
                new KIMLIK { ID = 4, TC_NO = 97850348520, AD = "Mustafa", SOYAD = "Işık", DOGUM_YERI = "Sivas", DOGUM_TARIHI = CreateUtcDate("21.12.2000"), ILETISIMID = 3 },
                new KIMLIK { ID = 5, TC_NO = 32756874239, AD = "Ayşe", SOYAD = "Erdoğan", DOGUM_YERI = "Uşak", DOGUM_TARIHI = CreateUtcDate("04.03.2001"), ILETISIMID = 5 },
                new KIMLIK { ID = 6, TC_NO = 98423479320, AD = "Fatma", SOYAD = "Korkmaz", DOGUM_YERI = "Kütahya", DOGUM_TARIHI = CreateUtcDate("01.01.2001"), ILETISIMID = 2 }
            );
            modelBuilder.Entity<ILETISIM>().HasData(
                new ILETISIM { ID = 1, ADRES = "CUMHURİYET MAH. BİRİNCİ SOK. İKİNCİ APT. NO:111/6", IL = "ANKARA", ILCE = "YENİMAHALLE", EMAIL = "abc@hotmail.com", GSM = "5332342342" },
                new ILETISIM { ID = 2, ADRES = "KUŞADASI SOK. NO:123 KARAAĞAÇ", IL = "ANKARA", ILCE = "ÇANKAYA", EMAIL = "def@gmail.com", GSM = "5437657567" },
                new ILETISIM { ID = 3, ADRES = "TURAN GÜNEŞ BULVARI TAMTAM SİTESİ 13. CAD. NO:51", IL = "ANKARA", ILCE = "KEÇİÖREN", EMAIL = "ghi@abc.com", GSM = "5305464646" },
                new ILETISIM { ID = 4, ADRES = "DEMİRCİKARA MAH. B.ONAT CAD. HEDE SİT. B BLOK NO : 1", IL = "ANKARA", ILCE = "PURSAKLAR", EMAIL = "mno@xyz.com", GSM = "5555424245" },
                new ILETISIM { ID = 5, ADRES = "AHMET HAMDİ SOK. NO:19/15", IL = "ANKARA", ILCE = "SİNCAN", EMAIL = "prs@hotmail.com", GSM = "5302908432" },
                new ILETISIM { ID = 6, ADRES = "SİTELER MAHALLESİ 6223 SOKAK DURU APT. NO:11 KAT:3", IL = "ANKARA", ILCE = "POLATLI", EMAIL = "klm@outlook.com", GSM = "5408932042" }
            );
            modelBuilder.Entity<DERS>().HasData(
                new DERS { ID = 1, DERS_KODU = "HUM101", DERS_ADI = "Türk Demokrasi Tarihi", DURUM = 1, KREDI = 5 },
                new DERS { ID = 2, DERS_KODU = "MATH102", DERS_ADI = "Calculus 2", DURUM = 0, KREDI = 6 },
                new DERS { ID = 3, DERS_KODU = "MATE103", DERS_ADI = "Metalurjiye Giriş", DURUM = 0, KREDI = 6 },
                new DERS { ID = 4, DERS_KODU = "GRA105", DERS_ADI = "Grafik Dizayn", DURUM = 1, KREDI = 5 },
                new DERS { ID = 5, DERS_KODU = "CMPE201", DERS_ADI = "Bilgisayar Teknolojileri", DURUM = 1, KREDI = 4 },
                new DERS { ID = 6, DERS_KODU = "ENG102", DERS_ADI = "İngilizce 2", DURUM = 1, KREDI = 4 },
                new DERS { ID = 7, DERS_KODU = "MATH201", DERS_ADI = "İleri Calculus", DURUM = 1, KREDI = 6 }
            );
            modelBuilder.Entity<MUFREDAT>().HasData(
                new MUFREDAT { ID = 1, MUFREDAT_ADI = "BilgMuh_Mufredat" },
                new MUFREDAT { ID = 2, MUFREDAT_ADI = "GrafikMuh_Mufredat" },
                new MUFREDAT { ID = 3, MUFREDAT_ADI = "IngDilEdebiyat_Muf" }
            );
            modelBuilder.Entity<MUFREDAT_DERSLER>().HasData(
                new MUFREDAT_DERSLER { ID = 1, MUFREDATID = 1, DERSID = 2 },
                new MUFREDAT_DERSLER { ID = 2, MUFREDATID = 1, DERSID = 5 },
                new MUFREDAT_DERSLER { ID = 3, MUFREDATID = 1, DERSID = 6 },
                new MUFREDAT_DERSLER { ID = 4, MUFREDATID = 1, DERSID = 7 },
                new MUFREDAT_DERSLER { ID = 5, MUFREDATID = 2, DERSID = 1 },
                new MUFREDAT_DERSLER { ID = 6, MUFREDATID = 2, DERSID = 2 },
                new MUFREDAT_DERSLER { ID = 7, MUFREDATID = 2, DERSID = 3 },
                new MUFREDAT_DERSLER { ID = 8, MUFREDATID = 2, DERSID = 4 },
                new MUFREDAT_DERSLER { ID = 9, MUFREDATID = 2, DERSID = 6 },
                new MUFREDAT_DERSLER { ID = 10, MUFREDATID = 2, DERSID = 7 },
                new MUFREDAT_DERSLER { ID = 11, MUFREDATID = 3, DERSID = 1 },
                new MUFREDAT_DERSLER { ID = 12, MUFREDATID = 3, DERSID = 4 },
                new MUFREDAT_DERSLER { ID = 13, MUFREDATID = 3, DERSID = 5 },
                new MUFREDAT_DERSLER { ID = 14, MUFREDATID = 3, DERSID = 6 }
            );
            modelBuilder.Entity<KULLANICI>().HasData(
                new KULLANICI { ID = 1, KULLANICI_ADI = "hasan.ersoy", SIFRE = SetPassword("Haser1."), TUR = KULLANICI_TIPI.ADMIN, KIMLIKID = 1 },
                new KULLANICI { ID = 2, KULLANICI_ADI = "mehmet.yilmaz", SIFRE = SetPassword("Mehyil6!"), TUR = KULLANICI_TIPI.USER, KIMLIKID = 2 },
                new KULLANICI { ID = 3, KULLANICI_ADI = "ahmet.unal", SIFRE = SetPassword("Ahun23+"), TUR = KULLANICI_TIPI.USER, KIMLIKID = 3 },
                new KULLANICI { ID = 4, KULLANICI_ADI = "mustafa.isik", SIFRE = SetPassword("Musi64%"), TUR = KULLANICI_TIPI.USER, KIMLIKID = 4 },
                new KULLANICI { ID = 5, KULLANICI_ADI = "ayse.erdogan", SIFRE = SetPassword("Ayer33."), TUR = KULLANICI_TIPI.USER, KIMLIKID = 5 },
                new KULLANICI { ID = 6, KULLANICI_ADI = "fatma.korkmaz", SIFRE = SetPassword("Fatkor12%"), TUR = KULLANICI_TIPI.USER, KIMLIKID = 6 }
            );
            //modelBuilder.Entity<DERS_KAYIT>().HasData(
            //    new DERS_KAYIT { ID = 1, OGRID = 3, DERSID = 3, CREATED_DATE = CreateUtcDate("04.11.2021") },
            //    new DERS_KAYIT { ID = 2, OGRID = 4, DERSID = 6, CREATED_DATE = CreateUtcDate("04.11.2021") }
            //);



        }

        private DateTime CreateUtcDate(string dateString)
        {
            string format = "dd.MM.yyyy";
            DateTime date = DateTime.ParseExact(dateString, format, CultureInfo.InvariantCulture);

            // Convert the parsed date to UTC
            DateTime utcDate = date.ToUniversalTime();

            return utcDate;
        }

        public string SetPassword(string password)
        {
            var salt = BCrypt.Net.BCrypt.GenerateSalt(12);

            return BCrypt.Net.BCrypt.HashPassword(password, salt);
        }

    }
}