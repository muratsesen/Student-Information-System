using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class MufredatDersIliski : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DERSLER_MUFREDAT_DERSLER_MUFREDAT_DERSLERID",
                table: "DERSLER");

            migrationBuilder.DropIndex(
                name: "IX_DERSLER_MUFREDAT_DERSLERID",
                table: "DERSLER");

            migrationBuilder.DeleteData(
                table: "MUFREDAT_DERSLER",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MUFREDAT_DERSLER",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MUFREDAT_DERSLER",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MUFREDAT_DERSLER",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MUFREDAT_DERSLER",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MUFREDAT_DERSLER",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MUFREDAT_DERSLER",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MUFREDAT_DERSLER",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MUFREDAT_DERSLER",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "MUFREDAT_DERSLER",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "MUFREDAT_DERSLER",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "MUFREDAT_DERSLER",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "MUFREDAT_DERSLER",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "MUFREDAT_DERSLER",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "OGRENCILER",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OGRENCILER",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OGRENCILER",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OGRENCILER",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OGRENCILER",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "MUFREDAT_DERSLERID",
                table: "DERSLER");

            migrationBuilder.AddColumn<int>(
                name: "DERSID",
                table: "MUFREDAT_DERSLER",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MUFREDATID",
                table: "MUFREDAT_DERSLER",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 1,
                column: "SIFRE",
                value: "$2b$12$OT0cEACtEvbguEu8.s.6Uuu.sK1C0MXcDiil5pvnSw1e6Kn0nSiyi");

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 2,
                column: "SIFRE",
                value: "$2b$12$FlVTOE5NlkV5Yoy915xgMeHu3Ht96tllywnxhg9ba.zlq67KTWTC6");

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 3,
                column: "SIFRE",
                value: "$2b$12$UpQS0hL.q3DG9R4csmvmzOCC8LhIrfQj77/XgCiIwqtGPcRaCzyDa");

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 4,
                column: "SIFRE",
                value: "$2b$12$m1vXmADnURuKELVuY14ZtOyMgdP74kZtZXP.MzdG17uyWIdJeO.h.");

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 5,
                column: "SIFRE",
                value: "$2b$12$a9O456JY/AL4jkwTUl/nEuJizrM6rqaXfj8rY3XVGBrVKlCDsLvGi");

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 6,
                column: "SIFRE",
                value: "$2b$12$ZkciXLmX.pM6rNJ1ZN3ZBO.JGiPOZRhG2x4ljCqT4xYSMxSW5H38y");

            migrationBuilder.CreateIndex(
                name: "IX_OGRENCILER_MUFREDAT_ID",
                table: "OGRENCILER",
                column: "MUFREDAT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MUFREDAT_DERSLER_DERSID",
                table: "MUFREDAT_DERSLER",
                column: "DERSID");

            migrationBuilder.CreateIndex(
                name: "IX_MUFREDAT_DERSLER_MUFREDATID",
                table: "MUFREDAT_DERSLER",
                column: "MUFREDATID");

            migrationBuilder.AddForeignKey(
                name: "FK_MUFREDAT_DERSLER_DERSLER_DERSID",
                table: "MUFREDAT_DERSLER",
                column: "DERSID",
                principalTable: "DERSLER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MUFREDAT_DERSLER_MUFREDATLAR_MUFREDATID",
                table: "MUFREDAT_DERSLER",
                column: "MUFREDATID",
                principalTable: "MUFREDATLAR",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OGRENCILER_MUFREDATLAR_MUFREDAT_ID",
                table: "OGRENCILER",
                column: "MUFREDAT_ID",
                principalTable: "MUFREDATLAR",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MUFREDAT_DERSLER_DERSLER_DERSID",
                table: "MUFREDAT_DERSLER");

            migrationBuilder.DropForeignKey(
                name: "FK_MUFREDAT_DERSLER_MUFREDATLAR_MUFREDATID",
                table: "MUFREDAT_DERSLER");

            migrationBuilder.DropForeignKey(
                name: "FK_OGRENCILER_MUFREDATLAR_MUFREDAT_ID",
                table: "OGRENCILER");

            migrationBuilder.DropIndex(
                name: "IX_OGRENCILER_MUFREDAT_ID",
                table: "OGRENCILER");

            migrationBuilder.DropIndex(
                name: "IX_MUFREDAT_DERSLER_DERSID",
                table: "MUFREDAT_DERSLER");

            migrationBuilder.DropIndex(
                name: "IX_MUFREDAT_DERSLER_MUFREDATID",
                table: "MUFREDAT_DERSLER");

            migrationBuilder.DropColumn(
                name: "DERSID",
                table: "MUFREDAT_DERSLER");

            migrationBuilder.DropColumn(
                name: "MUFREDATID",
                table: "MUFREDAT_DERSLER");

            migrationBuilder.AddColumn<int>(
                name: "MUFREDAT_DERSLERID",
                table: "DERSLER",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "DERSLER",
                keyColumn: "ID",
                keyValue: 1,
                column: "MUFREDAT_DERSLERID",
                value: null);

            migrationBuilder.UpdateData(
                table: "DERSLER",
                keyColumn: "ID",
                keyValue: 2,
                column: "MUFREDAT_DERSLERID",
                value: null);

            migrationBuilder.UpdateData(
                table: "DERSLER",
                keyColumn: "ID",
                keyValue: 3,
                column: "MUFREDAT_DERSLERID",
                value: null);

            migrationBuilder.UpdateData(
                table: "DERSLER",
                keyColumn: "ID",
                keyValue: 4,
                column: "MUFREDAT_DERSLERID",
                value: null);

            migrationBuilder.UpdateData(
                table: "DERSLER",
                keyColumn: "ID",
                keyValue: 5,
                column: "MUFREDAT_DERSLERID",
                value: null);

            migrationBuilder.UpdateData(
                table: "DERSLER",
                keyColumn: "ID",
                keyValue: 6,
                column: "MUFREDAT_DERSLERID",
                value: null);

            migrationBuilder.UpdateData(
                table: "DERSLER",
                keyColumn: "ID",
                keyValue: 7,
                column: "MUFREDAT_DERSLERID",
                value: null);

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 1,
                column: "SIFRE",
                value: "$2b$12$3m3GSlgPye82PSh17RssBORWjzBPfq9h78AUyR8UMA86QgkNOvlW.");

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 2,
                column: "SIFRE",
                value: "$2b$12$RnNuXQMTn9PDyxv73AD9YuRdqoqut3YxZ73e/m/5Ke6zw7FC9IwxG");

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 3,
                column: "SIFRE",
                value: "$2b$12$QpVNcKcsWBBkaRTcg30vsOJhGjFF0VplH/mOLUQJtpxnb8.0T7CSG");

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 4,
                column: "SIFRE",
                value: "$2b$12$yblH0TfXNSK8NigbmcYzReSW8aWIRobWICX1kh4si7roY8Ac6ojZe");

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 5,
                column: "SIFRE",
                value: "$2b$12$XccFAomJ63O4dDP3NVRGBO00EmD0UW0GBKHHj7L8cdTQVt7I6aw02");

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 6,
                column: "SIFRE",
                value: "$2b$12$WKoYKfwMEwATv7ghvCSgmO05cEm.2nYmN7RK2drJT25lbkFaMI7li");

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

            migrationBuilder.CreateIndex(
                name: "IX_DERSLER_MUFREDAT_DERSLERID",
                table: "DERSLER",
                column: "MUFREDAT_DERSLERID");

            migrationBuilder.AddForeignKey(
                name: "FK_DERSLER_MUFREDAT_DERSLER_MUFREDAT_DERSLERID",
                table: "DERSLER",
                column: "MUFREDAT_DERSLERID",
                principalTable: "MUFREDAT_DERSLER",
                principalColumn: "ID");
        }
    }
}
