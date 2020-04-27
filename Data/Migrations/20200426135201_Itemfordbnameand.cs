using Microsoft.EntityFrameworkCore.Migrations;

namespace AlikHalafim.Data.Migrations
{
    public partial class Itemfordbnameand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "CartItemForDb",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductNumber",
                table: "CartItemForDb",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "CartItemForDb");

            migrationBuilder.DropColumn(
                name: "ProductNumber",
                table: "CartItemForDb");
        }
    }
}
