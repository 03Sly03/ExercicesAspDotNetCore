using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoListWebApp.Migrations
{
    public partial class ModelMYTaskModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "status",
                table: "task",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "task",
                keyColumn: "Id",
                keyValue: 1,
                column: "status",
                value: false);

            migrationBuilder.UpdateData(
                table: "task",
                keyColumn: "Id",
                keyValue: 2,
                column: "status",
                value: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "status",
                table: "task",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.UpdateData(
                table: "task",
                keyColumn: "Id",
                keyValue: 1,
                column: "status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "task",
                keyColumn: "Id",
                keyValue: 2,
                column: "status",
                value: 0);
        }
    }
}
