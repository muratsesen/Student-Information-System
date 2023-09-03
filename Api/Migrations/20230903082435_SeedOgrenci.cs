using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedOgrenci : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 1,
                column: "SIFRE",
                value: "$2b$12$A0/Da2pZ9Q1nK8PxmNE.eOhtF5EoOASpEwFQMZ5IDzXSFJhX6xraO");

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 2,
                column: "SIFRE",
                value: "$2b$12$tePIobKfNk.GljatjJ/yi.j2p3/Bs0hzeSBIBiJNhbziZAjyF0Xnm");

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 3,
                column: "SIFRE",
                value: "$2b$12$Yt8zrgVNQ3b1ZV/hQOHmqe9Z8fnYturztBIGaoMu5UxChMAEVfj9C");

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 4,
                column: "SIFRE",
                value: "$2b$12$lxdmgZeByc4RxkJ07OG2P.YFcrhiamG37XxPX9GiI40Qn256057Eu");

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 5,
                column: "SIFRE",
                value: "$2b$12$VOoROXZcLC6XUsJyihmx9uuM8BSYPRbwLH1kqjU4nkYlPwHxLyCY.");

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 6,
                column: "SIFRE",
                value: "$2b$12$U.2zJ8VvsgVxYCfGc.hzvOJXJlUsExy.RTc/4CqbsfjdIyVV4nrGm");

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
        }
    }
}
