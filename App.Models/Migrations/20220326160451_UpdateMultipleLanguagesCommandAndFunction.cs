using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Models.Migrations
{
    public partial class UpdateMultipleLanguagesCommandAndFunction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "functions");

            migrationBuilder.DropColumn(
                name: "name",
                table: "commands");

            migrationBuilder.CreateTable(
                name: "command_details",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lang_id = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    command_id = table.Column<string>(type: "varchar(50)", nullable: true),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    create_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deleted = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_command_details", x => x.id);
                    table.ForeignKey(
                        name: "fk_command_details_commands_command_id",
                        column: x => x.command_id,
                        principalTable: "commands",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_command_details_langs_lang_id",
                        column: x => x.lang_id,
                        principalTable: "langs",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "function_details",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lang_id = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    function_id = table.Column<string>(type: "varchar(50)", nullable: true),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    create_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deleted = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_function_details", x => x.id);
                    table.ForeignKey(
                        name: "fk_function_details_functions_function_id",
                        column: x => x.function_id,
                        principalTable: "functions",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_function_details_langs_lang_id",
                        column: x => x.lang_id,
                        principalTable: "langs",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_command_details_command_id",
                table: "command_details",
                column: "command_id");

            migrationBuilder.CreateIndex(
                name: "ix_command_details_id",
                table: "command_details",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_command_details_lang_id",
                table: "command_details",
                column: "lang_id");

            migrationBuilder.CreateIndex(
                name: "ix_function_details_function_id",
                table: "function_details",
                column: "function_id");

            migrationBuilder.CreateIndex(
                name: "ix_function_details_id",
                table: "function_details",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_function_details_lang_id",
                table: "function_details",
                column: "lang_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "command_details");

            migrationBuilder.DropTable(
                name: "function_details");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "functions",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "commands",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
