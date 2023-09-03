using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class OgrenciKimlikRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 1,
                column: "SIFRE",
                value: "$2b$12$wPcCAt3DIZvvj1iPQ1Fg8OGL.cuG3IxjqWpYWmOB11MCoa43V7ndW");

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 2,
                column: "SIFRE",
                value: "$2b$12$lyvk/ahlbt1pJvN82Um1TOoTtN7CdqGZTKMM93MNS/MpPLqLD4Yni");

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 3,
                column: "SIFRE",
                value: "$2b$12$y9rBsq1VPCHw8hS7KwBKyOmDkK58Pbc4vc8Uhqd7oWz4eZH8.uoYi");

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 4,
                column: "SIFRE",
                value: "$2b$12$4qKfgjOV1ER3y9OsG7ACsefLMOzvzHR7zdpGA2TLUkxZI06t3GRfG");

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 5,
                column: "SIFRE",
                value: "$2b$12$n1RlD9E8BxzAUKYT0Lq5veKFcv/mkEQaxGi2DawbiJMfmV9WrsK4K");

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 6,
                column: "SIFRE",
                value: "$2b$12$tcCqBxfeIZDWVf1ovUL87OiMjIv0/gUYPm..4oBRzXATH29jrp82G");

            migrationBuilder.CreateIndex(
                name: "IX_OGRENCILER_KIMLIK_ID",
                table: "OGRENCILER",
                column: "KIMLIK_ID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OGRENCILER_KIMLIKLER_KIMLIK_ID",
                table: "OGRENCILER",
                column: "KIMLIK_ID",
                principalTable: "KIMLIKLER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OGRENCILER_KIMLIKLER_KIMLIK_ID",
                table: "OGRENCILER");

            migrationBuilder.DropIndex(
                name: "IX_OGRENCILER_KIMLIK_ID",
                table: "OGRENCILER");

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 1,
                column: "SIFRE",
                value: "$2b$12$TXjU8PzzuCjIQ6EWP46.a.tUA2QV6wMJqEljHyZVgKt3iB1y19JXy");

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 2,
                column: "SIFRE",
                value: "$2b$12$ZEqKuF0ufRsje5bqj1zqZ.C7gHYWkbi0ZL2kWItY46ZTTx5s8hvFG");

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 3,
                column: "SIFRE",
                value: "$2b$12$H18hrotZ0Xdf9O0x8Y8Hp./ZIr.BLoN8V/YRhsP0FSVGfbK9q12Qq");

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 4,
                column: "SIFRE",
                value: "$2b$12$4/2sHyAZ.VCQraeKK6RWEOXFmBi8GQ4n3XEljziMVGD5xEZpPgf12");

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 5,
                column: "SIFRE",
                value: "$2b$12$LMmmfzSDevjHrXO04tkpGuvOmbEuwCSVxyQoevZeEHHBb3YAndVRC");

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 6,
                column: "SIFRE",
                value: "$2b$12$2IgwNipUNBFbKoPUs7SCW.hHkL1BEBI3nlYS1gW6uo8JL.Wx.JfI2");
        }
    }
}
