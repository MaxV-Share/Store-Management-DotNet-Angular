using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace App.Migrations
{
    public partial class AddProductDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "product_details",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    product_id = table.Column<int>(type: "int", nullable: true),
                    lang_id = table.Column<string>(type: "varchar(256)", nullable: true),
                    name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
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
                    table.PrimaryKey("pk_product_details", x => x.id);
                    table.ForeignKey(
                        name: "fk_product_details_langs_lang_id",
                        column: x => x.lang_id,
                        principalTable: "langs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_product_details_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_product_details_id",
                table: "product_details",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_product_details_lang_id",
                table: "product_details",
                column: "lang_id");

            migrationBuilder.CreateIndex(
                name: "ix_product_details_product_id",
                table: "product_details",
                column: "product_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product_details");
        }
    }
}
