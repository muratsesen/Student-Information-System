using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class MufredatDersRel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MUFREDAT_DERSLER_DERSLER_DERSID",
                table: "MUFREDAT_DERSLER");

            migrationBuilder.DropForeignKey(
                name: "FK_MUFREDAT_DERSLER_MUFREDATLAR_MUFREDATID",
                table: "MUFREDAT_DERSLER");

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

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 1,
                column: "SIFRE",
                value: "$2b$12$tJkTWkLO4JV1vQ5TV3f6WuKfYO0N/T2Ph/MXRwvDceAWJR7cUH71q");

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 2,
                column: "SIFRE",
                value: "$2b$12$rGphSs7jSB2dfGxl6b5BpOjGbGzTOVgmzJQljbW9i.FCjAQBMPRN.");

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 3,
                column: "SIFRE",
                value: "$2b$12$QIeD8FeDonx8i8gM1DCeYOCIkEDvjcY9rl/WXXQVWwxsJUp6uNn02");

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 4,
                column: "SIFRE",
                value: "$2b$12$T7oS0JnTFPfvz1da/Jrca.wVTZu8Vkh08xyeRHUwgKV06MLHEe4Ci");

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 5,
                column: "SIFRE",
                value: "$2b$12$AuB.osoX/8S9RYbo2hSGdesB7qS.Qx1vCIYBOEtEDVNlJlHuYSQlS");

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 6,
                column: "SIFRE",
                value: "$2b$12$BJaNkj2bHmbwCCzzOxn1ue1NABHpBp9y8xAQ.e0J9qL44qqY5qrw2");

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

            migrationBuilder.CreateIndex(
                name: "IX_MUFREDAT_DERSLER_DERS_ID",
                table: "MUFREDAT_DERSLER",
                column: "DERS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MUFREDAT_DERSLER_MUFREDAT_ID",
                table: "MUFREDAT_DERSLER",
                column: "MUFREDAT_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_MUFREDAT_DERSLER_DERSLER_DERS_ID",
                table: "MUFREDAT_DERSLER",
                column: "DERS_ID",
                principalTable: "DERSLER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MUFREDAT_DERSLER_MUFREDATLAR_MUFREDAT_ID",
                table: "MUFREDAT_DERSLER",
                column: "MUFREDAT_ID",
                principalTable: "MUFREDATLAR",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MUFREDAT_DERSLER_DERSLER_DERS_ID",
                table: "MUFREDAT_DERSLER");

            migrationBuilder.DropForeignKey(
                name: "FK_MUFREDAT_DERSLER_MUFREDATLAR_MUFREDAT_ID",
                table: "MUFREDAT_DERSLER");

            migrationBuilder.DropIndex(
                name: "IX_MUFREDAT_DERSLER_DERS_ID",
                table: "MUFREDAT_DERSLER");

            migrationBuilder.DropIndex(
                name: "IX_MUFREDAT_DERSLER_MUFREDAT_ID",
                table: "MUFREDAT_DERSLER");

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
        }
    }
}
