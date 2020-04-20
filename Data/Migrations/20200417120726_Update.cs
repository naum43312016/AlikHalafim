using Microsoft.EntityFrameworkCore.Migrations;

namespace AlikHalafim.Data.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Product");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
