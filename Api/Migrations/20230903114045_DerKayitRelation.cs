using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class DerKayitRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "UQ_DersKayit",
                table: "DERS_KAYIT",
                columns: new[] { "OGR_ID", "DERS_ID" });

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 1,
                column: "SIFRE",
                value: "$2b$12$PTIzyNajUtEEaduDaxrh7uBJpPhBC86iaAueJmR2yfsYqFLGulhwK");

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 2,
                column: "SIFRE",
                value: "$2b$12$ljiuktI1hJXKyMj0DVSIyOluv5ADOs4PvCT8Yb.Zkh2JNmt.23SRu");

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 3,
                column: "SIFRE",
                value: "$2b$12$kKv1E4wx8XkFtEZEOoDGYOB.Y4Ol.P6H0.Cj7NVYDR8Ql68NAdgtS");

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 4,
                column: "SIFRE",
                value: "$2b$12$0.wxRjYhnMdzXUyKTAQVMO45GH68aasvQpXU7.5Vxji2RcdCifmWq");

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 5,
                column: "SIFRE",
                value: "$2b$12$DA9dhYd4VToAaWH5cW9zqe4sTtHQBz2O/Qgff4iL17JW54tZ67j9G");

            migrationBuilder.UpdateData(
                table: "KULLANICILAR",
                keyColumn: "ID",
                keyValue: 6,
                column: "SIFRE",
                value: "$2b$12$KTbFgzEApgjmZx8KDWABeur2PDgwxh.wErGBZ7D6oIuZ7qVkPDN0q");

            migrationBuilder.CreateIndex(
                name: "IX_DERS_KAYIT_DERS_ID",
                table: "DERS_KAYIT",
                column: "DERS_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_DERS_KAYIT_DERSLER_DERS_ID",
                table: "DERS_KAYIT",
                column: "DERS_ID",
                principalTable: "DERSLER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DERS_KAYIT_OGRENCILER_OGR_ID",
                table: "DERS_KAYIT",
                column: "OGR_ID",
                principalTable: "OGRENCILER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DERS_KAYIT_DERSLER_DERS_ID",
                table: "DERS_KAYIT");

            migrationBuilder.DropForeignKey(
                name: "FK_DERS_KAYIT_OGRENCILER_OGR_ID",
                table: "DERS_KAYIT");

            migrationBuilder.DropUniqueConstraint(
                name: "UQ_DersKayit",
                table: "DERS_KAYIT");

            migrationBuilder.DropIndex(
                name: "IX_DERS_KAYIT_DERS_ID",
                table: "DERS_KAYIT");

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
        }
    }
}
