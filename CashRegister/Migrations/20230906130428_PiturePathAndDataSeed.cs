using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CashRegister.Migrations
{
    public partial class PiturePathAndDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PicturePath",
                table: "product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "id",
                keyValue: 1,
                column: "PicturePath",
                value: "https://m.media-amazon.com/images/I/81mP4fmvvLL.__AC_SY300_SX300_QL70_ML2_.jpg");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "id",
                keyValue: 2,
                column: "PicturePath",
                value: "https://m.media-amazon.com/images/I/91EogiCRqfL.__AC_SY300_SX300_QL70_ML2_.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PicturePath",
                table: "product");
        }
    }
}
