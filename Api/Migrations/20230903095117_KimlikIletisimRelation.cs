using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class KimlikIletisimRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "ILETISIMLER",
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

            migrationBuilder.AddForeignKey(
                name: "FK_ILETISIMLER_KIMLIKLER_ID",
                table: "ILETISIMLER",
                column: "ID",
                principalTable: "KIMLIKLER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ILETISIMLER_KIMLIKLER_ID",
                table: "ILETISIMLER");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "ILETISIMLER",
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
        }
    }
}
