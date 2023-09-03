﻿// <auto-generated />
using System;
using Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230903095117_KimlikIletisimRelation")]
    partial class KimlikIletisimRelation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("DERS_ID")
                        .HasColumnType("integer");

                    b.Property<int>("OGR_ID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.ToTable("DERS_KAYIT");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CREATED_DATE = new DateTime(2021, 11, 3, 21, 0, 0, 0, DateTimeKind.Utc),
                            DERS_ID = 3,
                            OGR_ID = 3
                        },
                        new
                        {
                            ID = 2,
                            CREATED_DATE = new DateTime(2021, 11, 3, 21, 0, 0, 0, DateTimeKind.Utc),
                            DERS_ID = 6,
                            OGR_ID = 4
                        });
                });

            modelBuilder.Entity("Api.Data.Models.ILETISIM", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("integer");

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
                        .HasColumnType("integer");

                    b.Property<string>("AD")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DOGUM_TARIHI")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DOGUM_YERI")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ILETISIM_ID")
                        .HasColumnType("integer");

                    b.Property<string>("SOYAD")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("TC_NO")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.ToTable("KIMLIKLER");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            AD = "Hasan",
                            DOGUM_TARIHI = new DateTime(1983, 10, 10, 21, 0, 0, 0, DateTimeKind.Utc),
                            DOGUM_YERI = "Kayseri",
                            ILETISIM_ID = 4,
                            SOYAD = "Ersoy",
                            TC_NO = 45456747611L
                        },
                        new
                        {
                            ID = 2,
                            AD = "Mehmet",
                            DOGUM_TARIHI = new DateTime(2000, 3, 11, 22, 0, 0, 0, DateTimeKind.Utc),
                            DOGUM_YERI = "Adana",
                            ILETISIM_ID = 1,
                            SOYAD = "Yılmaz",
                            TC_NO = 67967856634L
                        },
                        new
                        {
                            ID = 3,
                            AD = "Ahmet",
                            DOGUM_TARIHI = new DateTime(2001, 6, 13, 21, 0, 0, 0, DateTimeKind.Utc),
                            DOGUM_YERI = "Ankara",
                            ILETISIM_ID = 6,
                            SOYAD = "Ünal",
                            TC_NO = 72347322958L
                        },
                        new
                        {
                            ID = 4,
                            AD = "Mustafa",
                            DOGUM_TARIHI = new DateTime(2000, 12, 20, 22, 0, 0, 0, DateTimeKind.Utc),
                            DOGUM_YERI = "Sivas",
                            ILETISIM_ID = 3,
                            SOYAD = "Işık",
                            TC_NO = 97850348520L
                        },
                        new
                        {
                            ID = 5,
                            AD = "Ayşe",
                            DOGUM_TARIHI = new DateTime(2001, 3, 3, 22, 0, 0, 0, DateTimeKind.Utc),
                            DOGUM_YERI = "Uşak",
                            ILETISIM_ID = 5,
                            SOYAD = "Erdoğan",
                            TC_NO = 32756874239L
                        },
                        new
                        {
                            ID = 6,
                            AD = "Fatma",
                            DOGUM_TARIHI = new DateTime(2000, 12, 31, 22, 0, 0, 0, DateTimeKind.Utc),
                            DOGUM_YERI = "Kütahya",
                            ILETISIM_ID = 2,
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

                    b.Property<int>("KIMLIK_ID")
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

                    b.ToTable("KULLANICILAR");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            KIMLIK_ID = 1,
                            KULLANICI_ADI = "hasan.ersoy",
                            SIFRE = "$2b$12$TXjU8PzzuCjIQ6EWP46.a.tUA2QV6wMJqEljHyZVgKt3iB1y19JXy",
                            TUR = 0
                        },
                        new
                        {
                            ID = 2,
                            KIMLIK_ID = 2,
                            KULLANICI_ADI = "mehmet.yilmaz",
                            SIFRE = "$2b$12$ZEqKuF0ufRsje5bqj1zqZ.C7gHYWkbi0ZL2kWItY46ZTTx5s8hvFG",
                            TUR = 1
                        },
                        new
                        {
                            ID = 3,
                            KIMLIK_ID = 3,
                            KULLANICI_ADI = "ahmet.unal",
                            SIFRE = "$2b$12$H18hrotZ0Xdf9O0x8Y8Hp./ZIr.BLoN8V/YRhsP0FSVGfbK9q12Qq",
                            TUR = 1
                        },
                        new
                        {
                            ID = 4,
                            KIMLIK_ID = 4,
                            KULLANICI_ADI = "mustafa.isik",
                            SIFRE = "$2b$12$4/2sHyAZ.VCQraeKK6RWEOXFmBi8GQ4n3XEljziMVGD5xEZpPgf12",
                            TUR = 1
                        },
                        new
                        {
                            ID = 5,
                            KIMLIK_ID = 5,
                            KULLANICI_ADI = "ayse.erdogan",
                            SIFRE = "$2b$12$LMmmfzSDevjHrXO04tkpGuvOmbEuwCSVxyQoevZeEHHBb3YAndVRC",
                            TUR = 1
                        },
                        new
                        {
                            ID = 6,
                            KIMLIK_ID = 6,
                            KULLANICI_ADI = "fatma.korkmaz",
                            SIFRE = "$2b$12$2IgwNipUNBFbKoPUs7SCW.hHkL1BEBI3nlYS1gW6uo8JL.Wx.JfI2",
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

                    b.Property<int>("DERS_ID")
                        .HasColumnType("integer");

                    b.Property<int>("MUFREDAT_ID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("DERS_ID");

                    b.HasIndex("MUFREDAT_ID");

                    b.ToTable("MUFREDAT_DERSLER");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            DERS_ID = 2,
                            MUFREDAT_ID = 1
                        },
                        new
                        {
                            ID = 2,
                            DERS_ID = 5,
                            MUFREDAT_ID = 1
                        },
                        new
                        {
                            ID = 3,
                            DERS_ID = 6,
                            MUFREDAT_ID = 1
                        },
                        new
                        {
                            ID = 4,
                            DERS_ID = 7,
                            MUFREDAT_ID = 1
                        },
                        new
                        {
                            ID = 5,
                            DERS_ID = 1,
                            MUFREDAT_ID = 2
                        },
                        new
                        {
                            ID = 6,
                            DERS_ID = 2,
                            MUFREDAT_ID = 2
                        },
                        new
                        {
                            ID = 7,
                            DERS_ID = 3,
                            MUFREDAT_ID = 2
                        },
                        new
                        {
                            ID = 8,
                            DERS_ID = 4,
                            MUFREDAT_ID = 2
                        },
                        new
                        {
                            ID = 9,
                            DERS_ID = 6,
                            MUFREDAT_ID = 2
                        },
                        new
                        {
                            ID = 10,
                            DERS_ID = 7,
                            MUFREDAT_ID = 2
                        },
                        new
                        {
                            ID = 11,
                            DERS_ID = 1,
                            MUFREDAT_ID = 3
                        },
                        new
                        {
                            ID = 12,
                            DERS_ID = 4,
                            MUFREDAT_ID = 3
                        },
                        new
                        {
                            ID = 13,
                            DERS_ID = 5,
                            MUFREDAT_ID = 3
                        },
                        new
                        {
                            ID = 14,
                            DERS_ID = 6,
                            MUFREDAT_ID = 3
                        });
                });

            modelBuilder.Entity("Api.Data.Models.OGRENCI", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("KIMLIK_ID")
                        .HasColumnType("integer");

                    b.Property<int>("MUFREDAT_ID")
                        .HasColumnType("integer");

                    b.Property<int>("OGR_NO")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("MUFREDAT_ID");

                    b.ToTable("OGRENCILER");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            KIMLIK_ID = 3,
                            MUFREDAT_ID = 1,
                            OGR_NO = 27482379
                        },
                        new
                        {
                            ID = 2,
                            KIMLIK_ID = 5,
                            MUFREDAT_ID = 1,
                            OGR_NO = 23462368
                        },
                        new
                        {
                            ID = 3,
                            KIMLIK_ID = 6,
                            MUFREDAT_ID = 2,
                            OGR_NO = 34565479
                        },
                        new
                        {
                            ID = 4,
                            KIMLIK_ID = 2,
                            MUFREDAT_ID = 2,
                            OGR_NO = 53456346
                        },
                        new
                        {
                            ID = 5,
                            KIMLIK_ID = 4,
                            MUFREDAT_ID = 3,
                            OGR_NO = 34674575
                        });
                });

            modelBuilder.Entity("Api.Data.Models.ILETISIM", b =>
                {
                    b.HasOne("Api.Data.Models.KIMLIK", null)
                        .WithOne("ILETISIM")
                        .HasForeignKey("Api.Data.Models.ILETISIM", "ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Api.Data.Models.KIMLIK", b =>
                {
                    b.HasOne("Api.Data.Models.KULLANICI", null)
                        .WithOne("KIMLIK")
                        .HasForeignKey("Api.Data.Models.KIMLIK", "ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Api.Data.Models.MUFREDAT_DERSLER", b =>
                {
                    b.HasOne("Api.Data.Models.DERS", "DERS")
                        .WithMany("MUFREDAT_DERSLERs")
                        .HasForeignKey("DERS_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Data.Models.MUFREDAT", "MUFREDAT")
                        .WithMany("MUFREDAT_DERSLER")
                        .HasForeignKey("MUFREDAT_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DERS");

                    b.Navigation("MUFREDAT");
                });

            modelBuilder.Entity("Api.Data.Models.OGRENCI", b =>
                {
                    b.HasOne("Api.Data.Models.MUFREDAT", "MUFREDAT")
                        .WithMany("OGRENCILER")
                        .HasForeignKey("MUFREDAT_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MUFREDAT");
                });

            modelBuilder.Entity("Api.Data.Models.DERS", b =>
                {
                    b.Navigation("MUFREDAT_DERSLERs");
                });

            modelBuilder.Entity("Api.Data.Models.KIMLIK", b =>
                {
                    b.Navigation("ILETISIM")
                        .IsRequired();
                });

            modelBuilder.Entity("Api.Data.Models.KULLANICI", b =>
                {
                    b.Navigation("KIMLIK")
                        .IsRequired();
                });

            modelBuilder.Entity("Api.Data.Models.MUFREDAT", b =>
                {
                    b.Navigation("MUFREDAT_DERSLER");

                    b.Navigation("OGRENCILER");
                });
#pragma warning restore 612, 618
        }
    }
}
