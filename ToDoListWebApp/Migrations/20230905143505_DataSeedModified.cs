using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoListWebApp.Migrations
{
    public partial class DataSeedModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "task",
                columns: new[] { "Id", "description", "name", "status" },
                values: new object[] { 3, "Faire le barbecue", "Jardinage", true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "task",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
