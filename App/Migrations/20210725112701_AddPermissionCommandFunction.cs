using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace App.Migrations
{
    public partial class AddPermissionCommandFunction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "uuid",
                table: "products");

            migrationBuilder.DropColumn(
                name: "uuid",
                table: "product_details");

            migrationBuilder.DropColumn(
                name: "uuid",
                table: "langs");

            migrationBuilder.DropColumn(
                name: "uuid",
                table: "discounts");

            migrationBuilder.DropColumn(
                name: "uuid",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "uuid",
                table: "category_details");

            migrationBuilder.DropColumn(
                name: "uuid",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "uuid",
                table: "bills");

            migrationBuilder.DropColumn(
                name: "uuid",
                table: "bill_details");

            migrationBuilder.CreateTable(
                name: "commands",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    create_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    update_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    create_by = table.Column<string>(type: "text", nullable: true),
                    update_by = table.Column<string>(type: "text", nullable: true),
                    deleted = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_commands", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "functions",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    url = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    sort_order = table.Column<int>(type: "int", nullable: false),
                    parent_id = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    icon = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    create_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    update_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    create_by = table.Column<string>(type: "text", nullable: true),
                    update_by = table.Column<string>(type: "text", nullable: true),
                    deleted = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_functions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "command_in_function",
                columns: table => new
                {
                    id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    command_id = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    function_id = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    create_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    update_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    create_by = table.Column<string>(type: "text", nullable: true),
                    update_by = table.Column<string>(type: "text", nullable: true),
                    deleted = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_command_in_function", x => x.id);
                    table.ForeignKey(
                        name: "fk_command_in_function_commands_command_id",
                        column: x => x.command_id,
                        principalTable: "commands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_command_in_function_functions_function_id",
                        column: x => x.function_id,
                        principalTable: "functions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "permissions",
                columns: table => new
                {
                    id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    function_id = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    role_id = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    command_id = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    create_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    update_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    create_by = table.Column<string>(type: "text", nullable: true),
                    update_by = table.Column<string>(type: "text", nullable: true),
                    deleted = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_permissions", x => x.id);
                    table.ForeignKey(
                        name: "fk_permissions_commands_command_id",
                        column: x => x.command_id,
                        principalTable: "commands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_permissions_functions_function_id",
                        column: x => x.function_id,
                        principalTable: "functions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_permissions_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "AspNetRoles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_command_in_function_command_id",
                table: "command_in_function",
                column: "command_id");

            migrationBuilder.CreateIndex(
                name: "ix_command_in_function_function_id",
                table: "command_in_function",
                column: "function_id");

            migrationBuilder.CreateIndex(
                name: "ix_command_in_function_id",
                table: "command_in_function",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_commands_id",
                table: "commands",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_functions_id",
                table: "functions",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_permissions_command_id",
                table: "permissions",
                column: "command_id");

            migrationBuilder.CreateIndex(
                name: "ix_permissions_function_id",
                table: "permissions",
                column: "function_id");

            migrationBuilder.CreateIndex(
                name: "ix_permissions_id",
                table: "permissions",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_permissions_role_id",
                table: "permissions",
                column: "role_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "command_in_function");

            migrationBuilder.DropTable(
                name: "permissions");

            migrationBuilder.DropTable(
                name: "commands");

            migrationBuilder.DropTable(
                name: "functions");

            migrationBuilder.AddColumn<byte[]>(
                name: "uuid",
                table: "products",
                type: "varbinary(16)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "uuid",
                table: "product_details",
                type: "varbinary(16)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "uuid",
                table: "langs",
                type: "varbinary(16)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "uuid",
                table: "discounts",
                type: "varbinary(16)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "uuid",
                table: "customers",
                type: "varbinary(16)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "uuid",
                table: "category_details",
                type: "varbinary(16)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "uuid",
                table: "categories",
                type: "varbinary(16)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "uuid",
                table: "bills",
                type: "varbinary(16)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "uuid",
                table: "bill_details",
                type: "varbinary(16)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
