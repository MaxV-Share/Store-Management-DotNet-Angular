using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class DeleteProductName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "products",
                type: "varchar(256)",
                maxLength: 256,
                nullable: true);
        }
    }
}
