using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class UpdateBillDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "bill_details");

            migrationBuilder.DropColumn(
                name: "product_code",
                table: "bill_details");

            migrationBuilder.AddColumn<int>(
                name: "quantity",
                table: "bill_details",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "quantity",
                table: "bill_details");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "bill_details",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "product_code",
                table: "bill_details",
                type: "text",
                nullable: true);
        }
    }
}
