using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class UpdateCategoriandAddCategories_detail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "categories");

            migrationBuilder.AddColumn<int>(
                name: "parent_id",
                table: "categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_categories_parent_id",
                table: "categories",
                column: "parent_id");

            migrationBuilder.AddForeignKey(
                name: "fk_categories_categories_parent_id",
                table: "categories",
                column: "parent_id",
                principalTable: "categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_categories_categories_parent_id",
                table: "categories");

            migrationBuilder.DropIndex(
                name: "ix_categories_parent_id",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "parent_id",
                table: "categories");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "categories",
                type: "varchar(256)",
                maxLength: 256,
                nullable: true);
        }
    }
}
