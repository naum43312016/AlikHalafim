using Microsoft.EntityFrameworkCore.Migrations;

namespace AlikHalafim.Data.Migrations
{
    public partial class UpdateProductManufacturer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Manufacturer",
                table: "Product",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Manufacturer",
                table: "Product");
        }
    }
}
