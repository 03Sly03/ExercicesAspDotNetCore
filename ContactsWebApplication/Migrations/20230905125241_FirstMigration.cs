using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactsWebApplication.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "marmoset",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marmoset", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "marmoset",
                columns: new[] { "id", "age", "name" },
                values: new object[] { 1, 5, "Poupi" });

            migrationBuilder.InsertData(
                table: "marmoset",
                columns: new[] { "id", "age", "name" },
                values: new object[] { 2, 3, "Mig" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "marmoset");
        }
    }
}
