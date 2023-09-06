using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoListWebApp.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "task",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_task", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "task",
                columns: new[] { "Id", "description", "name", "status" },
                values: new object[] { 1, "Casser les verres", "Vaisselle", 0 });

            migrationBuilder.InsertData(
                table: "task",
                columns: new[] { "Id", "description", "name", "status" },
                values: new object[] { 2, "Casser des coquilles de cacahuète", "Sport", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "task");
        }
    }
}
