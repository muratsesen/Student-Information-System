using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DERS_KAYIT",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OGR_ID = table.Column<int>(type: "integer", nullable: false),
                    DERS_ID = table.Column<int>(type: "integer", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DERS_KAYIT", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DERSLER",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DERS_KODU = table.Column<string>(type: "text", nullable: false),
                    DERS_ADI = table.Column<string>(type: "text", nullable: false),
                    DURUM = table.Column<int>(type: "integer", nullable: false),
                    KREDI = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DERSLER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ILETISIMLER",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ADRES = table.Column<string>(type: "text", nullable: false),
                    IL = table.Column<string>(type: "text", nullable: false),
                    ILCE = table.Column<string>(type: "text", nullable: false),
                    EMAIL = table.Column<string>(type: "text", nullable: false),
                    GSM = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ILETISIMLER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "KIMLIKLER",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TC_NO = table.Column<long>(type: "bigint", nullable: false),
                    AD = table.Column<string>(type: "text", nullable: false),
                    SOYAD = table.Column<string>(type: "text", nullable: false),
                    DOGUM_YERI = table.Column<string>(type: "text", nullable: false),
                    DOGUM_TARIHI = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ILETISIM_ID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KIMLIKLER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "KULLANICILAR",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KULLANICI_ADI = table.Column<string>(type: "text", nullable: false),
                    SIFRE = table.Column<string>(type: "text", nullable: false),
                    TUR = table.Column<int>(type: "integer", nullable: false),
                    KIMLIK_ID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KULLANICILAR", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MUFREDAT_DERSLER",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MUFREDAT_ID = table.Column<int>(type: "integer", nullable: false),
                    DERS_ID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MUFREDAT_DERSLER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MUFREDATLAR",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MUFREDAT_ADI = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MUFREDATLAR", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OGRENCILER",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OGR_NO = table.Column<int>(type: "integer", nullable: false),
                    KIMLIK_ID = table.Column<int>(type: "integer", nullable: false),
                    MUFREDAT_ID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OGRENCILER", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "DERSLER",
                columns: new[] { "ID", "DERS_ADI", "DERS_KODU", "DURUM", "KREDI" },
                values: new object[,]
                {
                    { 1, "Türk Demokrasi Tarihi", "HUM101", 1, 5 },
                    { 2, "Calculus 2", "MATH102", 0, 6 },
                    { 3, "Metalurjiye Giriş", "MATE103", 0, 6 },
                    { 4, "Grafik Dizayn", "GRA105", 1, 5 },
                    { 5, "Bilgisayar Teknolojileri", "CMPE201", 1, 4 },
                    { 6, "İngilizce 2", "ENG102", 1, 4 },
                    { 7, "İleri Calculus", "MATH201", 1, 6 }
                });

            migrationBuilder.InsertData(
                table: "DERS_KAYIT",
                columns: new[] { "ID", "CREATED_DATE", "DERS_ID", "OGR_ID" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 11, 3, 21, 0, 0, 0, DateTimeKind.Utc), 3, 3 },
                    { 2, new DateTime(2021, 11, 3, 21, 0, 0, 0, DateTimeKind.Utc), 6, 4 }
                });

            migrationBuilder.InsertData(
                table: "ILETISIMLER",
                columns: new[] { "ID", "ADRES", "EMAIL", "GSM", "IL", "ILCE" },
                values: new object[,]
                {
                    { 1, "CUMHURİYET MAH. BİRİNCİ SOK. İKİNCİ APT. NO:111/6", "abc@hotmail.com", "5332342342", "ANKARA", "YENİMAHALLE" },
                    { 2, "KUŞADASI SOK. NO:123 KARAAĞAÇ", "def@gmail.com", "5437657567", "ANKARA", "ÇANKAYA" },
                    { 3, "TURAN GÜNEŞ BULVARI TAMTAM SİTESİ 13. CAD. NO:51", "ghi@abc.com", "5305464646", "ANKARA", "KEÇİÖREN" },
                    { 4, "DEMİRCİKARA MAH. B.ONAT CAD. HEDE SİT. B BLOK NO : 1", "mno@xyz.com", "5555424245", "ANKARA", "PURSAKLAR" },
                    { 5, "AHMET HAMDİ SOK. NO:19/15", "prs@hotmail.com", "5302908432", "ANKARA", "SİNCAN" },
                    { 6, "SİTELER MAHALLESİ 6223 SOKAK DURU APT. NO:11 KAT:3", "klm@outlook.com", "5408932042", "ANKARA", "POLATLI" }
                });

            migrationBuilder.InsertData(
                table: "KIMLIKLER",
                columns: new[] { "ID", "AD", "DOGUM_TARIHI", "DOGUM_YERI", "ILETISIM_ID", "SOYAD", "TC_NO" },
                values: new object[,]
                {
                    { 1, "Hasan", new DateTime(1983, 10, 10, 21, 0, 0, 0, DateTimeKind.Utc), "Kayseri", 4, "Ersoy", 45456747611L },
                    { 2, "Mehmet", new DateTime(2000, 3, 11, 22, 0, 0, 0, DateTimeKind.Utc), "Adana", 1, "Yılmaz", 67967856634L },
                    { 3, "Ahmet", new DateTime(2001, 6, 13, 21, 0, 0, 0, DateTimeKind.Utc), "Ankara", 6, "Ünal", 72347322958L },
                    { 4, "Mustafa", new DateTime(2000, 12, 20, 22, 0, 0, 0, DateTimeKind.Utc), "Sivas", 3, "Işık", 97850348520L },
                    { 5, "Ayşe", new DateTime(2001, 3, 3, 22, 0, 0, 0, DateTimeKind.Utc), "Uşak", 5, "Erdoğan", 32756874239L },
                    { 6, "Fatma", new DateTime(2000, 12, 31, 22, 0, 0, 0, DateTimeKind.Utc), "Kütahya", 2, "Korkmaz", 98423479320L }
                });

            migrationBuilder.InsertData(
                table: "KULLANICILAR",
                columns: new[] { "ID", "KIMLIK_ID", "KULLANICI_ADI", "SIFRE", "TUR" },
                values: new object[,]
                {
                    { 1, 1, "hasan.ersoy", "$2b$12$ATMgLhxYK1nwzebAksGecuBGZ2C4wa6uH10Dqgl605ePj.JN89lh.", 0 },
                    { 2, 2, "mehmet.yilmaz", "$2b$12$c7WIyeB.vwUKJZYzdIRgyejsR2UlKqSjXwLIN/nwLnuF.DbfYTJGW", 1 },
                    { 3, 3, "ahmet.unal", "$2b$12$Ad7.i3ql4/SlChQviJ950.oh5fXD5SoUswbjwroRwU61Qv0JZpQT2", 1 },
                    { 4, 4, "mustafa.isik", "$2b$12$KZfgl.tfckas3PgRQ7zki.n63deohHwdu1yuK4ixk1u9oD0giPtA6", 1 },
                    { 5, 5, "ayse.erdogan", "$2b$12$a7a5Kg4icQ.DOE5oUiDkyutlNQHcGnWjfaAXcgwtLvcbXasluH5/m", 1 },
                    { 6, 6, "fatma.korkmaz", "$2b$12$ZIQv7fQp0Birtr6rxZS3mem8WTWS576l1Y.LplsvXIAbKquA5FA9m", 1 }
                });

            migrationBuilder.InsertData(
                table: "MUFREDATLAR",
                columns: new[] { "ID", "MUFREDAT_ADI" },
                values: new object[,]
                {
                    { 1, "BilgMuh_Mufredat" },
                    { 2, "GrafikMuh_Mufredat" },
                    { 3, "IngDilEdebiyat_Muf" }
                });

            migrationBuilder.InsertData(
                table: "MUFREDAT_DERSLER",
                columns: new[] { "ID", "DERS_ID", "MUFREDAT_ID" },
                values: new object[,]
                {
                    { 1, 2, 1 },
                    { 2, 5, 1 },
                    { 3, 6, 1 },
                    { 4, 7, 1 },
                    { 5, 1, 2 },
                    { 6, 2, 2 },
                    { 7, 3, 2 },
                    { 8, 4, 2 },
                    { 9, 6, 2 },
                    { 10, 7, 2 },
                    { 11, 1, 3 },
                    { 12, 4, 3 },
                    { 13, 5, 3 },
                    { 14, 6, 3 }
                });

            migrationBuilder.InsertData(
                table: "OGRENCILER",
                columns: new[] { "ID", "KIMLIK_ID", "MUFREDAT_ID", "OGR_NO" },
                values: new object[,]
                {
                    { 1, 3, 1, 27482379 },
                    { 2, 5, 1, 23462368 },
                    { 3, 6, 2, 34565479 },
                    { 4, 2, 2, 53456346 },
                    { 5, 4, 3, 34674575 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DERS_KAYIT");

            migrationBuilder.DropTable(
                name: "DERSLER");

            migrationBuilder.DropTable(
                name: "ILETISIMLER");

            migrationBuilder.DropTable(
                name: "KIMLIKLER");

            migrationBuilder.DropTable(
                name: "KULLANICILAR");

            migrationBuilder.DropTable(
                name: "MUFREDAT_DERSLER");

            migrationBuilder.DropTable(
                name: "MUFREDATLAR");

            migrationBuilder.DropTable(
                name: "OGRENCILER");
        }
    }
}
