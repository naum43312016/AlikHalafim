using Microsoft.EntityFrameworkCore.Migrations;

namespace AlikHalafim.Data.Migrations
{
    public partial class ProductAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatalogNumber = table.Column<string>(nullable: true),
                    OriginalNumbers = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Rank = table.Column<int>(nullable: false),
                    BigDescription = table.Column<string>(nullable: true),
                    ProductName = table.Column<string>(nullable: true),
                    MainDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
