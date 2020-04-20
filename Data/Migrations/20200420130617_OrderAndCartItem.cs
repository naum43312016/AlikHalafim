using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlikHalafim.Data.Migrations
{
    public partial class OrderAndCartItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    PaymentStatus = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    PaymentMethod = table.Column<string>(nullable: true),
                    DeliveryMethod = table.Column<string>(nullable: true),
                    CustomerName = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    TransactionId = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    HouseNumber = table.Column<string>(nullable: true),
                    AppartmentNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CartItemForDb",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItemForDb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItemForDb_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItemForDb_OrderId",
                table: "CartItemForDb",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItemForDb");

            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
