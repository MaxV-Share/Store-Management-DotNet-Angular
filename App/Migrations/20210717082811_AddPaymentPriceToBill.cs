using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class AddPaymentPriceToBill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "payment_amount",
                table: "bills",
                type: "double",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "payment_amount",
                table: "bills");
        }
    }
}
