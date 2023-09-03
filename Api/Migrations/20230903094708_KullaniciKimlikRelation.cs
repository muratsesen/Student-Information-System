using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class KullaniciKimlikRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "KIMLIKLER",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 1,
                column: "SIFRE",
                value: "$2b$12$oqL/G1LpvOpD4sCvjOX1Ie5TeZFXkZSAOtkl2ziIOW6VqEfok5Swi");

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 2,
                column: "SIFRE",
                value: "$2b$12$.9MFlIuLnXVZ7AN/08YNTuVQwtjl66.cTrrkQOjXQ3XtYFqFF9oAW");

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 3,
                column: "SIFRE",
                value: "$2b$12$DkXqIyGtbKoqGAQ545jG2uRN5wLi4yPwMVEDRdVVKd9si4Tvozjt6");

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 4,
                column: "SIFRE",
                value: "$2b$12$lfiPGzi7iLChfcsUXVolc.C5AHCxfBwC0iNHcNDnQ2qBuB6VmpkxG");

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 5,
                column: "SIFRE",
                value: "$2b$12$hsYwmuLTRrEgU8dzn9pEEuP9BjraiTJKPePdqW32LViDfHr5TtK32");

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 6,
                column: "SIFRE",
                value: "$2b$12$LBjmdbJMvlYmvTXUbYmgv.a1tHv1BKkrF/CdXcqO4FQX/z87xIiym");

            migrationBuilder.AddForeignKey(
                name: "FK_KIMLIKLER_KULLANICILAR_ID",
                table: "KIMLIKLER",
                column: "ID",
                principalTable: "KULLANICILAR",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KIMLIKLER_KULLANICILAR_ID",
                table: "KIMLIKLER");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "KIMLIKLER",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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
        }
    }
}
