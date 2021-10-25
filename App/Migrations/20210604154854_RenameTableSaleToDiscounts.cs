using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;
using System;

namespace App.Migrations
{
    public partial class RenameTableSaleToDiscounts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sale");

            migrationBuilder.CreateTable(
                name: "discounts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    percent_discount = table.Column<int>(type: "int", nullable: true),
                    max_discount_price = table.Column<double>(type: "double", nullable: true),
                    from_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    to_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    uuid = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    create_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    update_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    create_by = table.Column<string>(type: "text", nullable: true),
                    update_by = table.Column<string>(type: "text", nullable: true),
                    deleted = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_discounts", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_discounts_id",
                table: "discounts",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "discounts");

            migrationBuilder.CreateTable(
                name: "sale",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    create_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    create_by = table.Column<string>(type: "text", nullable: true),
                    deleted = table.Column<string>(type: "text", nullable: true),
                    from_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    max_discount_price = table.Column<double>(type: "double", nullable: true),
                    percent_discount = table.Column<int>(type: "int", nullable: true),
                    to_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    update_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    update_by = table.Column<string>(type: "text", nullable: true),
                    uuid = table.Column<byte[]>(type: "varbinary(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sale", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_sale_id",
                table: "sale",
                column: "id");
        }
    }
}
