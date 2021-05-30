using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace App.Migrations
{
    public partial class UpdateCategoryDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category_details",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    category_id = table.Column<int>(type: "int", nullable: true),
                    lang_id = table.Column<string>(type: "varchar(10)", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    uuid = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    create_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    update_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    create_by = table.Column<string>(type: "text", nullable: true),
                    update_by = table.Column<string>(type: "text", nullable: true),
                    deleted = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_category_details", x => x.id);
                    table.ForeignKey(
                        name: "fk_category_details_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_category_details_langs_lang_id",
                        column: x => x.lang_id,
                        principalTable: "langs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_category_details_category_id",
                table: "category_details",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "ix_category_details_id",
                table: "category_details",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_category_details_lang_id",
                table: "category_details",
                column: "lang_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "category_details");
        }
    }
}
