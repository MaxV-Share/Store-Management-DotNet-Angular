using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Models.Migrations
{
    public partial class AddComponentToFunction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "component",
                table: "functions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "component",
                table: "functions");
        }
    }
}
