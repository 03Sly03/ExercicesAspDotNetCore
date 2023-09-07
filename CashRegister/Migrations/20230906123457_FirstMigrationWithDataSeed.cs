using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CashRegister.Migrations
{
    public partial class FirstMigrationWithDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    stock = table.Column<int>(type: "int", nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_category_category_id",
                        column: x => x.category_id,
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "id", "name" },
                values: new object[] { 1, "Four" });

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "id", "name" },
                values: new object[] { 2, "Mug" });

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "id", "category_id", "description", "name", "price", "stock" },
                values: new object[] { 1, 1, "C'est un four à cuir", "Four", 449.99m, 0 });

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "id", "category_id", "description", "name", "price", "stock" },
                values: new object[] { 2, 1, "C'est un four à cuir avec des ondes microscopique", "Micro Onde", 99.99m, 0 });

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "id", "category_id", "description", "name", "price", "stock" },
                values: new object[] { 3, 2, "Un mug mexicain d'exception !", "El Mug", 0m, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_product_category_id",
                table: "product",
                column: "category_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "category");
        }
    }
}
