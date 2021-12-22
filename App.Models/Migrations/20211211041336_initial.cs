using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Models.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    normalized_name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    concurrency_stamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    full_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    normalized_user_name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    normalized_email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    email_confirmed = table.Column<bool>(type: "bit", nullable: false),
                    password_hash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    security_stamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    concurrency_stamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone_number_confirmed = table.Column<bool>(type: "bit", nullable: false),
                    two_factor_enabled = table.Column<bool>(type: "bit", nullable: false),
                    lockout_end = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    lockout_enabled = table.Column<bool>(type: "bit", nullable: false),
                    access_failed_count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    parent_id = table.Column<int>(type: "int", nullable: true),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    create_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deleted = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_categories", x => x.id);
                    table.ForeignKey(
                        name: "fk_categories_categories_parent_id",
                        column: x => x.parent_id,
                        principalTable: "categories",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "commands",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    create_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deleted = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_commands", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    phone_number = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    full_name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    birthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    create_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deleted = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_customers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "discounts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    percent_discount = table.Column<int>(type: "int", nullable: true),
                    max_discount_price = table.Column<double>(type: "float", nullable: true),
                    from_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    to_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    create_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deleted = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_discounts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "functions",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    url = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    sort_order = table.Column<int>(type: "int", nullable: false),
                    parent_id = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    icon = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    create_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deleted = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_functions", x => x.id);
                    table.ForeignKey(
                        name: "fk_functions_functions_parent_id",
                        column: x => x.parent_id,
                        principalTable: "functions",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "langs",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    order = table.Column<int>(type: "int", nullable: false),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    create_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deleted = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_langs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    claim_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    claim_value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_role_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_asp_net_role_claims_asp_net_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "AspNetRoles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    claim_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    claim_value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_asp_net_user_claims_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    login_provider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    provider_key = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    provider_display_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_logins", x => new { x.login_provider, x.provider_key });
                    table.ForeignKey(
                        name: "fk_asp_net_user_logins_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    role_id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_roles", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "fk_asp_net_user_roles_asp_net_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "AspNetRoles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_asp_net_user_roles_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    login_provider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_tokens", x => new { x.user_id, x.login_provider, x.name });
                    table.ForeignKey(
                        name: "fk_asp_net_user_tokens_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_id = table.Column<int>(type: "int", nullable: true),
                    code = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    price = table.Column<double>(type: "float", nullable: true),
                    percent_discount = table.Column<int>(type: "int", nullable: true),
                    max_discount_price = table.Column<double>(type: "float", nullable: true),
                    image_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    create_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deleted = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_products", x => x.id);
                    table.ForeignKey(
                        name: "fk_products_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "bills",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    user_payment_id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    total_price = table.Column<double>(type: "float", nullable: true),
                    discount_price = table.Column<double>(type: "float", nullable: true),
                    payment_amount = table.Column<double>(type: "float", nullable: true),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    create_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deleted = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_bills", x => x.id);
                    table.ForeignKey(
                        name: "fk_bills_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_bills_users_user_payment_id",
                        column: x => x.user_payment_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "command_in_function",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    command_id = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    function_id = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    create_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deleted = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "category_details",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    lang_id = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    create_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deleted = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_category_details", x => x.id);
                    table.ForeignKey(
                        name: "fk_category_details_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_category_details_langs_lang_id",
                        column: x => x.lang_id,
                        principalTable: "langs",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "permissions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    function_id = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    role_id = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    role_user_id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    role_id1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    command_id = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    create_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deleted = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_permissions", x => x.id);
                    table.ForeignKey(
                        name: "fk_permissions_commands_command_id",
                        column: x => x.command_id,
                        principalTable: "commands",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_permissions_functions_function_id",
                        column: x => x.function_id,
                        principalTable: "functions",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_permissions_user_roles_role_temp_id",
                        columns: x => new { x.role_user_id, x.role_id1 },
                        principalTable: "AspNetUserRoles",
                        principalColumns: new[] { "user_id", "role_id" });
                });

            migrationBuilder.CreateTable(
                name: "product_details",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    lang_id = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    create_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deleted = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_product_details", x => x.id);
                    table.ForeignKey(
                        name: "fk_product_details_langs_lang_id",
                        column: x => x.lang_id,
                        principalTable: "langs",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_product_details_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bill_details",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bill_id = table.Column<int>(type: "int", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: true),
                    price = table.Column<double>(type: "float", nullable: true),
                    discount_price = table.Column<double>(type: "float", nullable: true),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    create_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deleted = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_bill_details", x => x.id);
                    table.ForeignKey(
                        name: "fk_bill_details_bills_bill_id",
                        column: x => x.bill_id,
                        principalTable: "bills",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_bill_details_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_role_claims_role_id",
                table: "AspNetRoleClaims",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "normalized_name",
                unique: true,
                filter: "[normalized_name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_claims_user_id",
                table: "AspNetUserClaims",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_logins_user_id",
                table: "AspNetUserLogins",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_roles_role_id",
                table: "AspNetUserRoles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "normalized_email");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "normalized_user_name",
                unique: true,
                filter: "[normalized_user_name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ix_bill_details_bill_id",
                table: "bill_details",
                column: "bill_id");

            migrationBuilder.CreateIndex(
                name: "ix_bill_details_id",
                table: "bill_details",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_bill_details_product_id",
                table: "bill_details",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_bills_customer_id",
                table: "bills",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "ix_bills_id",
                table: "bills",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_bills_user_payment_id",
                table: "bills",
                column: "user_payment_id");

            migrationBuilder.CreateIndex(
                name: "ix_categories_id",
                table: "categories",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_categories_parent_id",
                table: "categories",
                column: "parent_id");

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
                name: "ix_customers_id",
                table: "customers",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_discounts_id",
                table: "discounts",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_functions_id",
                table: "functions",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_functions_parent_id",
                table: "functions",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "ix_langs_id",
                table: "langs",
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
                name: "ix_permissions_role_user_id_role_id1",
                table: "permissions",
                columns: new[] { "role_user_id", "role_id1" });

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

            migrationBuilder.CreateIndex(
                name: "ix_products_category_id",
                table: "products",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "ix_products_id",
                table: "products",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "bill_details");

            migrationBuilder.DropTable(
                name: "category_details");

            migrationBuilder.DropTable(
                name: "command_in_function");

            migrationBuilder.DropTable(
                name: "discounts");

            migrationBuilder.DropTable(
                name: "permissions");

            migrationBuilder.DropTable(
                name: "product_details");

            migrationBuilder.DropTable(
                name: "bills");

            migrationBuilder.DropTable(
                name: "commands");

            migrationBuilder.DropTable(
                name: "functions");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "langs");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
