using Microsoft.EntityFrameworkCore.Migrations;

namespace AlikHalafim.Data.Migrations
{
    public partial class UpdateProductVehicles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Vehicles",
                table: "Product",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vehicles",
                table: "Product");
        }
    }
}
