using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CashRegister.Migrations
{
    public partial class PicturePathColumnNameModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PicturePath",
                table: "product",
                newName: "picture_path");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "picture_path",
                table: "product",
                newName: "PicturePath");
        }
    }
}
