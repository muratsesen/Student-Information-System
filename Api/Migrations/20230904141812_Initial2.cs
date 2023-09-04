using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OGRID",
                table: "DERS_KAYIT");

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 1,
                column: "SIFRE",
                value: "$2b$12$JyP3af4mbXhNCWniSle8muflL9.htgnJK9rnxY1kzAE1OfPJGGIPy");

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 2,
                column: "SIFRE",
                value: "$2b$12$KTZPMT07r0MIrQb.Ur086.YLmgQPgeaFWwTufOEK9UQ.jc.HQkYHS");

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 3,
                column: "SIFRE",
                value: "$2b$12$F9VwrpPrhyRlT17WY4gEHezSrLM.FXy7qBWMQksJPeiKgURScpE6O");

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 4,
                column: "SIFRE",
                value: "$2b$12$ecVjOuJ2L1rDScWPYEAOyuv0YDq02G7n1344Y2fS3UlFP4F.EvKFC");

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 5,
                column: "SIFRE",
                value: "$2b$12$6ajSEEkPVsCkedJBdJzciOjyOiK8gxGJKdWyw1OMeF.rc8jp5R7o2");

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 6,
                column: "SIFRE",
                value: "$2b$12$otdvSUi2oUbSKmDSOuKHEO9nSqQ6UcDDvM02CzXatTOW1qNog.E5y");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OGRID",
                table: "DERS_KAYIT",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 1,
                column: "SIFRE",
                value: "$2b$12$og.AAtMwOQSQHk1AfL7iZenMubvegdHu37H.ClMXYjPAIExwwFNXi");

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 2,
                column: "SIFRE",
                value: "$2b$12$i05Fy0um0XF2gFiweWHXHe5a7gr8NlOTAxPPzwVSTKwQ3YChnU.7i");

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 3,
                column: "SIFRE",
                value: "$2b$12$Jpb8tqvwinYdMGnhGFHU.umNL4xqHHlJ2QlLS3FM/IflbYIiCCpCy");

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 4,
                column: "SIFRE",
                value: "$2b$12$x3PRYpUcEb5K9SQbu03H3up1nFX3CCehu6OLJx/40Squhjv/2GpW2");

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 5,
                column: "SIFRE",
                value: "$2b$12$8WBzAMs/Ag18SCv/OFKFFOpMPeQHeHXGa2ZdAB9c3TiuSH79I94wi");

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 6,
                column: "SIFRE",
                value: "$2b$12$UVjz1Gj63bMnGkt.ZlPBletNGtqwmDsienn0PVXN/SnWPRoRNqx4C");
        }
    }
}
