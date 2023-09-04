﻿// <auto-generated />
using System;
using Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Api.Data.Models.DERS", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("DERS_ADI")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DERS_KODU")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("DURUM")
                        .HasColumnType("integer");

                    b.Property<int>("KREDI")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.ToTable("DERSLER");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            DERS_ADI = "Türk Demokrasi Tarihi",
                            DERS_KODU = "HUM101",
                            DURUM = 1,
                            KREDI = 5
                        },
                        new
                        {
                            ID = 2,
                            DERS_ADI = "Calculus 2",
                            DERS_KODU = "MATH102",
                            DURUM = 0,
                            KREDI = 6
                        },
                        new
                        {
                            ID = 3,
                            DERS_ADI = "Metalurjiye Giriş",
                            DERS_KODU = "MATE103",
                            DURUM = 0,
                            KREDI = 6
                        },
                        new
                        {
                            ID = 4,
                            DERS_ADI = "Grafik Dizayn",
                            DERS_KODU = "GRA105",
                            DURUM = 1,
                            KREDI = 5
                        },
                        new
                        {
                            ID = 5,
                            DERS_ADI = "Bilgisayar Teknolojileri",
                            DERS_KODU = "CMPE201",
                            DURUM = 1,
                            KREDI = 4
                        },
                        new
                        {
                            ID = 6,
                            DERS_ADI = "İngilizce 2",
                            DERS_KODU = "ENG102",
                            DURUM = 1,
                            KREDI = 4
                        },
                        new
                        {
                            ID = 7,
                            DERS_ADI = "İleri Calculus",
                            DERS_KODU = "MATH201",
                            DURUM = 1,
                            KREDI = 6
                        });
                });

            modelBuilder.Entity("Api.Data.Models.DERS_KAYIT", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CREATED_DATE")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("DERSID")
                        .HasColumnType("integer");

                    b.Property<int>("OGRENCIID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("DERSID");

                    b.HasIndex("OGRENCIID");

                    b.ToTable("DERS_KAYIT");
                });

            modelBuilder.Entity("Api.Data.Models.ILETISIM", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("ADRES")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("EMAIL")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("GSM")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IL")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ILCE")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("ILETISIMLER");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            ADRES = "CUMHURİYET MAH. BİRİNCİ SOK. İKİNCİ APT. NO:111/6",
                            EMAIL = "abc@hotmail.com",
                            GSM = "5332342342",
                            IL = "ANKARA",
                            ILCE = "YENİMAHALLE"
                        },
                        new
                        {
                            ID = 2,
                            ADRES = "KUŞADASI SOK. NO:123 KARAAĞAÇ",
                            EMAIL = "def@gmail.com",
                            GSM = "5437657567",
                            IL = "ANKARA",
                            ILCE = "ÇANKAYA"
                        },
                        new
                        {
                            ID = 3,
                            ADRES = "TURAN GÜNEŞ BULVARI TAMTAM SİTESİ 13. CAD. NO:51",
                            EMAIL = "ghi@abc.com",
                            GSM = "5305464646",
                            IL = "ANKARA",
                            ILCE = "KEÇİÖREN"
                        },
                        new
                        {
                            ID = 4,
                            ADRES = "DEMİRCİKARA MAH. B.ONAT CAD. HEDE SİT. B BLOK NO : 1",
                            EMAIL = "mno@xyz.com",
                            GSM = "5555424245",
                            IL = "ANKARA",
                            ILCE = "PURSAKLAR"
                        },
                        new
                        {
                            ID = 5,
                            ADRES = "AHMET HAMDİ SOK. NO:19/15",
                            EMAIL = "prs@hotmail.com",
                            GSM = "5302908432",
                            IL = "ANKARA",
                            ILCE = "SİNCAN"
                        },
                        new
                        {
                            ID = 6,
                            ADRES = "SİTELER MAHALLESİ 6223 SOKAK DURU APT. NO:11 KAT:3",
                            EMAIL = "klm@outlook.com",
                            GSM = "5408932042",
                            IL = "ANKARA",
                            ILCE = "POLATLI"
                        });
                });

            modelBuilder.Entity("Api.Data.Models.KIMLIK", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("AD")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DOGUM_TARIHI")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DOGUM_YERI")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ILETISIMID")
                        .HasColumnType("integer");

                    b.Property<string>("SOYAD")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("TC_NO")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("ILETISIMID");

                    b.ToTable("KIMLIKLER");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            AD = "Hasan",
                            DOGUM_TARIHI = new DateTime(1983, 10, 10, 21, 0, 0, 0, DateTimeKind.Utc),
                            DOGUM_YERI = "Kayseri",
                            ILETISIMID = 4,
                            SOYAD = "Ersoy",
                            TC_NO = 45456747611L
                        },
                        new
                        {
                            ID = 2,
                            AD = "Mehmet",
                            DOGUM_TARIHI = new DateTime(2000, 3, 11, 22, 0, 0, 0, DateTimeKind.Utc),
                            DOGUM_YERI = "Adana",
                            ILETISIMID = 1,
                            SOYAD = "Yılmaz",
                            TC_NO = 67967856634L
                        },
                        new
                        {
                            ID = 3,
                            AD = "Ahmet",
                            DOGUM_TARIHI = new DateTime(2001, 6, 13, 21, 0, 0, 0, DateTimeKind.Utc),
                            DOGUM_YERI = "Ankara",
                            ILETISIMID = 6,
                            SOYAD = "Ünal",
                            TC_NO = 72347322958L
                        },
                        new
                        {
                            ID = 4,
                            AD = "Mustafa",
                            DOGUM_TARIHI = new DateTime(2000, 12, 20, 22, 0, 0, 0, DateTimeKind.Utc),
                            DOGUM_YERI = "Sivas",
                            ILETISIMID = 3,
                            SOYAD = "Işık",
                            TC_NO = 97850348520L
                        },
                        new
                        {
                            ID = 5,
                            AD = "Ayşe",
                            DOGUM_TARIHI = new DateTime(2001, 3, 3, 22, 0, 0, 0, DateTimeKind.Utc),
                            DOGUM_YERI = "Uşak",
                            ILETISIMID = 5,
                            SOYAD = "Erdoğan",
                            TC_NO = 32756874239L
                        },
                        new
                        {
                            ID = 6,
                            AD = "Fatma",
                            DOGUM_TARIHI = new DateTime(2000, 12, 31, 22, 0, 0, 0, DateTimeKind.Utc),
                            DOGUM_YERI = "Kütahya",
                            ILETISIMID = 2,
                            SOYAD = "Korkmaz",
                            TC_NO = 98423479320L
                        });
                });

            modelBuilder.Entity("Api.Data.Models.KULLANICI", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("KIMLIKID")
                        .HasColumnType("integer");

                    b.Property<string>("KULLANICI_ADI")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SIFRE")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TUR")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("KIMLIKID");

                    b.ToTable("KULLANICILAR");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            KIMLIKID = 1,
                            KULLANICI_ADI = "hasan.ersoy",
                            SIFRE = "$2b$12$JyP3af4mbXhNCWniSle8muflL9.htgnJK9rnxY1kzAE1OfPJGGIPy",
                            TUR = 0
                        },
                        new
                        {
                            ID = 2,
                            KIMLIKID = 2,
                            KULLANICI_ADI = "mehmet.yilmaz",
                            SIFRE = "$2b$12$KTZPMT07r0MIrQb.Ur086.YLmgQPgeaFWwTufOEK9UQ.jc.HQkYHS",
                            TUR = 1
                        },
                        new
                        {
                            ID = 3,
                            KIMLIKID = 3,
                            KULLANICI_ADI = "ahmet.unal",
                            SIFRE = "$2b$12$F9VwrpPrhyRlT17WY4gEHezSrLM.FXy7qBWMQksJPeiKgURScpE6O",
                            TUR = 1
                        },
                        new
                        {
                            ID = 4,
                            KIMLIKID = 4,
                            KULLANICI_ADI = "mustafa.isik",
                            SIFRE = "$2b$12$ecVjOuJ2L1rDScWPYEAOyuv0YDq02G7n1344Y2fS3UlFP4F.EvKFC",
                            TUR = 1
                        },
                        new
                        {
                            ID = 5,
                            KIMLIKID = 5,
                            KULLANICI_ADI = "ayse.erdogan",
                            SIFRE = "$2b$12$6ajSEEkPVsCkedJBdJzciOjyOiK8gxGJKdWyw1OMeF.rc8jp5R7o2",
                            TUR = 1
                        },
                        new
                        {
                            ID = 6,
                            KIMLIKID = 6,
                            KULLANICI_ADI = "fatma.korkmaz",
                            SIFRE = "$2b$12$otdvSUi2oUbSKmDSOuKHEO9nSqQ6UcDDvM02CzXatTOW1qNog.E5y",
                            TUR = 1
                        });
                });

            modelBuilder.Entity("Api.Data.Models.MUFREDAT", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("MUFREDAT_ADI")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("MUFREDATLAR");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            MUFREDAT_ADI = "BilgMuh_Mufredat"
                        },
                        new
                        {
                            ID = 2,
                            MUFREDAT_ADI = "GrafikMuh_Mufredat"
                        },
                        new
                        {
                            ID = 3,
                            MUFREDAT_ADI = "IngDilEdebiyat_Muf"
                        });
                });

            modelBuilder.Entity("Api.Data.Models.MUFREDAT_DERSLER", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("DERSID")
                        .HasColumnType("integer");

                    b.Property<int>("MUFREDATID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("DERSID");

                    b.HasIndex("MUFREDATID");

                    b.ToTable("MUFREDAT_DERSLER");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            DERSID = 2,
                            MUFREDATID = 1
                        },
                        new
                        {
                            ID = 2,
                            DERSID = 5,
                            MUFREDATID = 1
                        },
                        new
                        {
                            ID = 3,
                            DERSID = 6,
                            MUFREDATID = 1
                        },
                        new
                        {
                            ID = 4,
                            DERSID = 7,
                            MUFREDATID = 1
                        },
                        new
                        {
                            ID = 5,
                            DERSID = 1,
                            MUFREDATID = 2
                        },
                        new
                        {
                            ID = 6,
                            DERSID = 2,
                            MUFREDATID = 2
                        },
                        new
                        {
                            ID = 7,
                            DERSID = 3,
                            MUFREDATID = 2
                        },
                        new
                        {
                            ID = 8,
                            DERSID = 4,
                            MUFREDATID = 2
                        },
                        new
                        {
                            ID = 9,
                            DERSID = 6,
                            MUFREDATID = 2
                        },
                        new
                        {
                            ID = 10,
                            DERSID = 7,
                            MUFREDATID = 2
                        },
                        new
                        {
                            ID = 11,
                            DERSID = 1,
                            MUFREDATID = 3
                        },
                        new
                        {
                            ID = 12,
                            DERSID = 4,
                            MUFREDATID = 3
                        },
                        new
                        {
                            ID = 13,
                            DERSID = 5,
                            MUFREDATID = 3
                        },
                        new
                        {
                            ID = 14,
                            DERSID = 6,
                            MUFREDATID = 3
                        });
                });

            modelBuilder.Entity("Api.Data.Models.OGRENCI", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("KIMLIKID")
                        .HasColumnType("integer");

                    b.Property<int>("MUFREDATID")
                        .HasColumnType("integer");

                    b.Property<int>("OGR_NO")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("KIMLIKID");

                    b.HasIndex("MUFREDATID");

                    b.ToTable("OGRENCILER");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            KIMLIKID = 3,
                            MUFREDATID = 1,
                            OGR_NO = 27482379
                        },
                        new
                        {
                            ID = 2,
                            KIMLIKID = 5,
                            MUFREDATID = 1,
                            OGR_NO = 23462368
                        },
                        new
                        {
                            ID = 3,
                            KIMLIKID = 6,
                            MUFREDATID = 2,
                            OGR_NO = 34565479
                        },
                        new
                        {
                            ID = 4,
                            KIMLIKID = 2,
                            MUFREDATID = 2,
                            OGR_NO = 53456346
                        },
                        new
                        {
                            ID = 5,
                            KIMLIKID = 4,
                            MUFREDATID = 3,
                            OGR_NO = 34674575
                        });
                });

            modelBuilder.Entity("Api.Data.Models.DERS_KAYIT", b =>
                {
                    b.HasOne("Api.Data.Models.DERS", "DERS")
                        .WithMany("DERS_KAYITLARI")
                        .HasForeignKey("DERSID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Data.Models.OGRENCI", "OGRENCI")
                        .WithMany("DERS_KAYITLARI")
                        .HasForeignKey("OGRENCIID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DERS");

                    b.Navigation("OGRENCI");
                });

            modelBuilder.Entity("Api.Data.Models.KIMLIK", b =>
                {
                    b.HasOne("Api.Data.Models.ILETISIM", "ILETISIM")
                        .WithMany()
                        .HasForeignKey("ILETISIMID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ILETISIM");
                });

            modelBuilder.Entity("Api.Data.Models.KULLANICI", b =>
                {
                    b.HasOne("Api.Data.Models.KIMLIK", "KIMLIK")
                        .WithMany()
                        .HasForeignKey("KIMLIKID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KIMLIK");
                });

            modelBuilder.Entity("Api.Data.Models.MUFREDAT_DERSLER", b =>
                {
                    b.HasOne("Api.Data.Models.DERS", "DERS")
                        .WithMany("MUFREDAT_DERSLERs")
                        .HasForeignKey("DERSID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Data.Models.MUFREDAT", "MUFREDAT")
                        .WithMany("MUFREDAT_DERSLER")
                        .HasForeignKey("MUFREDATID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DERS");

                    b.Navigation("MUFREDAT");
                });

            modelBuilder.Entity("Api.Data.Models.OGRENCI", b =>
                {
                    b.HasOne("Api.Data.Models.KIMLIK", "KIMLIK")
                        .WithMany()
                        .HasForeignKey("KIMLIKID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Data.Models.MUFREDAT", "MUFREDAT")
                        .WithMany("OGRENCILER")
                        .HasForeignKey("MUFREDATID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KIMLIK");

                    b.Navigation("MUFREDAT");
                });

            modelBuilder.Entity("Api.Data.Models.DERS", b =>
                {
                    b.Navigation("DERS_KAYITLARI");

                    b.Navigation("MUFREDAT_DERSLERs");
                });

            modelBuilder.Entity("Api.Data.Models.MUFREDAT", b =>
                {
                    b.Navigation("MUFREDAT_DERSLER");

                    b.Navigation("OGRENCILER");
                });

            modelBuilder.Entity("Api.Data.Models.OGRENCI", b =>
                {
                    b.Navigation("DERS_KAYITLARI");
                });
#pragma warning restore 612, 618
        }
    }
}
