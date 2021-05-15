using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class UpdateEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    uuid = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    id = table.Column<int>(type: "int", nullable: false),
                    create_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    update_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    create_by = table.Column<string>(type: "text", nullable: true),
                    update_by = table.Column<string>(type: "text", nullable: true),
                    deleted = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_categories", x => x.uuid);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    uuid = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    phone_number = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    full_name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    birthday = table.Column<DateTime>(type: "datetime", nullable: true),
                    id = table.Column<int>(type: "int", nullable: false),
                    create_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    update_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    create_by = table.Column<string>(type: "text", nullable: true),
                    update_by = table.Column<string>(type: "text", nullable: true),
                    deleted = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_customers", x => x.uuid);
                });

            migrationBuilder.CreateTable(
                name: "sale",
                columns: table => new
                {
                    uuid = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    percent_discount = table.Column<int>(type: "int", nullable: true),
                    max_discount_price = table.Column<double>(type: "double", nullable: true),
                    id = table.Column<int>(type: "int", nullable: false),
                    create_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    update_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    create_by = table.Column<string>(type: "text", nullable: true),
                    update_by = table.Column<string>(type: "text", nullable: true),
                    deleted = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sale", x => x.uuid);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    uuid = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    category_uuid = table.Column<byte[]>(type: "varbinary(16)", nullable: true),
                    name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    code = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    price = table.Column<double>(type: "double", nullable: true),
                    percent_discount = table.Column<int>(type: "int", nullable: true),
                    max_discount_price = table.Column<double>(type: "double", nullable: true),
                    id = table.Column<int>(type: "int", nullable: false),
                    create_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    update_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    create_by = table.Column<string>(type: "text", nullable: true),
                    update_by = table.Column<string>(type: "text", nullable: true),
                    deleted = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_products", x => x.uuid);
                    table.ForeignKey(
                        name: "fk_products_categories_category_uuid",
                        column: x => x.category_uuid,
                        principalTable: "categories",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "bills",
                columns: table => new
                {
                    uuid = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    customer_uuid = table.Column<byte[]>(type: "varbinary(16)", nullable: true),
                    user_payment_id = table.Column<string>(type: "varchar(767)", nullable: true),
                    total_price = table.Column<double>(type: "double", nullable: true),
                    discount_price = table.Column<double>(type: "double", nullable: true),
                    id = table.Column<int>(type: "int", nullable: false),
                    create_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    update_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    create_by = table.Column<string>(type: "text", nullable: true),
                    update_by = table.Column<string>(type: "text", nullable: true),
                    deleted = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_bills", x => x.uuid);
                    table.ForeignKey(
                        name: "fk_bills_customers_customer_uuid",
                        column: x => x.customer_uuid,
                        principalTable: "customers",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_bills_users_user_payment_id",
                        column: x => x.user_payment_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "bill_details",
                columns: table => new
                {
                    uuid = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    bill_uuid = table.Column<byte[]>(type: "varbinary(16)", nullable: true),
                    product_uuid = table.Column<byte[]>(type: "varbinary(16)", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true),
                    product_code = table.Column<string>(type: "text", nullable: true),
                    price = table.Column<double>(type: "double", nullable: true),
                    discount_price = table.Column<double>(type: "double", nullable: true),
                    id = table.Column<int>(type: "int", nullable: false),
                    create_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    update_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    create_by = table.Column<string>(type: "text", nullable: true),
                    update_by = table.Column<string>(type: "text", nullable: true),
                    deleted = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_bill_details", x => x.uuid);
                    table.ForeignKey(
                        name: "fk_bill_details_bills_bill_uuid",
                        column: x => x.bill_uuid,
                        principalTable: "bills",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_bill_details_products_product_uuid",
                        column: x => x.product_uuid,
                        principalTable: "products",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_bill_details_bill_uuid",
                table: "bill_details",
                column: "bill_uuid");

            migrationBuilder.CreateIndex(
                name: "ix_bill_details_product_uuid",
                table: "bill_details",
                column: "product_uuid");

            migrationBuilder.CreateIndex(
                name: "ix_bills_customer_uuid",
                table: "bills",
                column: "customer_uuid");

            migrationBuilder.CreateIndex(
                name: "ix_bills_user_payment_id",
                table: "bills",
                column: "user_payment_id");

            migrationBuilder.CreateIndex(
                name: "ix_products_category_uuid",
                table: "products",
                column: "category_uuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bill_details");

            migrationBuilder.DropTable(
                name: "sale");

            migrationBuilder.DropTable(
                name: "bills");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
