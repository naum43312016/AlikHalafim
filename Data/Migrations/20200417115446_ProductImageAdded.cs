using Microsoft.EntityFrameworkCore.Migrations;

namespace AlikHalafim.Data.Migrations
{
    public partial class ProductImageAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductImage",
                table: "Product",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductImage",
                table: "Product");
        }
    }
}
