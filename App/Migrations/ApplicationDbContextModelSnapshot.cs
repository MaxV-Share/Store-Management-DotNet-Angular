﻿// <auto-generated />
using System;
using App.Infrastructures.Dbcontexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace App.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("App.Models.Entities.Bill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime")
                        .HasColumnName("create_at");

                    b.Property<string>("CreateBy")
                        .HasColumnType("text")
                        .HasColumnName("create_by");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("customer_id");

                    b.Property<string>("Deleted")
                        .HasColumnType("text")
                        .HasColumnName("deleted");

                    b.Property<double?>("DiscountPrice")
                        .HasColumnType("double")
                        .HasColumnName("discount_price");

                    b.Property<double?>("TotalPrice")
                        .HasColumnType("double")
                        .HasColumnName("total_price");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime")
                        .HasColumnName("update_at");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("text")
                        .HasColumnName("update_by");

                    b.Property<string>("UserPaymentId")
                        .HasColumnType("varchar(767)")
                        .HasColumnName("user_payment_id");

                    b.Property<byte[]>("Uuid")
                        .IsRequired()
                        .HasColumnType("varbinary(16)")
                        .HasColumnName("uuid");

                    b.HasKey("Id")
                        .HasName("pk_bills");

                    b.HasIndex("CustomerId")
                        .HasDatabaseName("ix_bills_customer_id");

                    b.HasIndex("Id")
                        .HasDatabaseName("ix_bills_id");

                    b.HasIndex("UserPaymentId")
                        .HasDatabaseName("ix_bills_user_payment_id");

                    b.ToTable("bills");
                });

            modelBuilder.Entity("App.Models.Entities.BillDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int?>("BillId")
                        .HasColumnType("int")
                        .HasColumnName("bill_id");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime")
                        .HasColumnName("create_at");

                    b.Property<string>("CreateBy")
                        .HasColumnType("text")
                        .HasColumnName("create_by");

                    b.Property<string>("Deleted")
                        .HasColumnType("text")
                        .HasColumnName("deleted");

                    b.Property<double?>("DiscountPrice")
                        .HasColumnType("double")
                        .HasColumnName("discount_price");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<double?>("Price")
                        .HasColumnType("double")
                        .HasColumnName("price");

                    b.Property<string>("ProductCode")
                        .HasColumnType("text")
                        .HasColumnName("product_code");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime")
                        .HasColumnName("update_at");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("text")
                        .HasColumnName("update_by");

                    b.Property<byte[]>("Uuid")
                        .IsRequired()
                        .HasColumnType("varbinary(16)")
                        .HasColumnName("uuid");

                    b.HasKey("Id")
                        .HasName("pk_bill_details");

                    b.HasIndex("BillId")
                        .HasDatabaseName("ix_bill_details_bill_id");

                    b.HasIndex("Id")
                        .HasDatabaseName("ix_bill_details_id");

                    b.HasIndex("ProductId")
                        .HasDatabaseName("ix_bill_details_product_id");

                    b.ToTable("bill_details");
                });

            modelBuilder.Entity("App.Models.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime")
                        .HasColumnName("create_at");

                    b.Property<string>("CreateBy")
                        .HasColumnType("text")
                        .HasColumnName("create_by");

                    b.Property<string>("Deleted")
                        .HasColumnType("text")
                        .HasColumnName("deleted");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int")
                        .HasColumnName("parent_id");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime")
                        .HasColumnName("update_at");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("text")
                        .HasColumnName("update_by");

                    b.Property<byte[]>("Uuid")
                        .IsRequired()
                        .HasColumnType("varbinary(16)")
                        .HasColumnName("uuid");

                    b.HasKey("Id")
                        .HasName("pk_categories");

                    b.HasIndex("Id")
                        .HasDatabaseName("ix_categories_id");

                    b.HasIndex("ParentId")
                        .HasDatabaseName("ix_categories_parent_id");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("App.Models.Entities.CategoryDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime")
                        .HasColumnName("create_at");

                    b.Property<string>("CreateBy")
                        .HasColumnType("text")
                        .HasColumnName("create_by");

                    b.Property<string>("Deleted")
                        .HasColumnType("text")
                        .HasColumnName("deleted");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("LangId")
                        .HasColumnType("varchar(767)")
                        .HasColumnName("lang_id");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime")
                        .HasColumnName("update_at");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("text")
                        .HasColumnName("update_by");

                    b.Property<byte[]>("Uuid")
                        .IsRequired()
                        .HasColumnType("varbinary(16)")
                        .HasColumnName("uuid");

                    b.HasKey("Id")
                        .HasName("pk_category_details");

                    b.HasIndex("CategoryId")
                        .HasDatabaseName("ix_category_details_category_id");

                    b.HasIndex("Id")
                        .HasDatabaseName("ix_category_details_id");

                    b.HasIndex("LangId")
                        .HasDatabaseName("ix_category_details_lang_id");

                    b.ToTable("category_details");
                });

            modelBuilder.Entity("App.Models.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime")
                        .HasColumnName("birthday");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime")
                        .HasColumnName("create_at");

                    b.Property<string>("CreateBy")
                        .HasColumnType("text")
                        .HasColumnName("create_by");

                    b.Property<string>("Deleted")
                        .HasColumnType("text")
                        .HasColumnName("deleted");

                    b.Property<string>("FullName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("full_name");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("phone_number");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime")
                        .HasColumnName("update_at");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("text")
                        .HasColumnName("update_by");

                    b.Property<byte[]>("Uuid")
                        .IsRequired()
                        .HasColumnType("varbinary(16)")
                        .HasColumnName("uuid");

                    b.HasKey("Id")
                        .HasName("pk_customers");

                    b.HasIndex("Id")
                        .HasDatabaseName("ix_customers_id");

                    b.ToTable("customers");
                });

            modelBuilder.Entity("App.Models.Entities.Lang", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(767)")
                        .HasColumnName("id");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime")
                        .HasColumnName("create_at");

                    b.Property<string>("CreateBy")
                        .HasColumnType("text")
                        .HasColumnName("create_by");

                    b.Property<string>("Deleted")
                        .HasColumnType("text")
                        .HasColumnName("deleted");

                    b.Property<string>("Name")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("name");

                    b.Property<int>("Order")
                        .HasColumnType("int")
                        .HasColumnName("order");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime")
                        .HasColumnName("update_at");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("text")
                        .HasColumnName("update_by");

                    b.Property<byte[]>("Uuid")
                        .IsRequired()
                        .HasColumnType("varbinary(16)")
                        .HasColumnName("uuid");

                    b.HasKey("Id")
                        .HasName("pk_langs");

                    b.HasIndex("Id")
                        .HasDatabaseName("ix_langs_id");

                    b.ToTable("langs");
                });

            modelBuilder.Entity("App.Models.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    b.Property<string>("Code")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("code");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime")
                        .HasColumnName("create_at");

                    b.Property<string>("CreateBy")
                        .HasColumnType("text")
                        .HasColumnName("create_by");

                    b.Property<string>("Deleted")
                        .HasColumnType("text")
                        .HasColumnName("deleted");

                    b.Property<double?>("MaxDiscountPrice")
                        .HasColumnType("double")
                        .HasColumnName("max_discount_price");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("name");

                    b.Property<int?>("PercentDiscount")
                        .HasColumnType("int")
                        .HasColumnName("percent_discount");

                    b.Property<double?>("Price")
                        .HasColumnType("double")
                        .HasColumnName("price");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime")
                        .HasColumnName("update_at");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("text")
                        .HasColumnName("update_by");

                    b.Property<byte[]>("Uuid")
                        .IsRequired()
                        .HasColumnType("varbinary(16)")
                        .HasColumnName("uuid");

                    b.HasKey("Id")
                        .HasName("pk_products");

                    b.HasIndex("CategoryId")
                        .HasDatabaseName("ix_products_category_id");

                    b.HasIndex("Id")
                        .HasDatabaseName("ix_products_id");

                    b.ToTable("products");
                });

            modelBuilder.Entity("App.Models.Entities.ProductDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime")
                        .HasColumnName("create_at");

                    b.Property<string>("CreateBy")
                        .HasColumnType("text")
                        .HasColumnName("create_by");

                    b.Property<string>("Deleted")
                        .HasColumnType("text")
                        .HasColumnName("deleted");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("LangId")
                        .HasColumnType("varchar(10)")
                        .HasColumnName("lang_id");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("name");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime")
                        .HasColumnName("update_at");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("text")
                        .HasColumnName("update_by");

                    b.Property<byte[]>("Uuid")
                        .IsRequired()
                        .HasColumnType("varbinary(16)")
                        .HasColumnName("uuid");

                    b.HasKey("Id")
                        .HasName("pk_product_details");

                    b.HasIndex("Id")
                        .HasDatabaseName("ix_product_details_id");

                    b.HasIndex("LangId")
                        .HasDatabaseName("ix_product_details_lang_id");

                    b.HasIndex("ProductId")
                        .HasDatabaseName("ix_product_details_product_id");

                    b.ToTable("product_details");
                });

            modelBuilder.Entity("App.Models.Entities.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime")
                        .HasColumnName("create_at");

                    b.Property<string>("CreateBy")
                        .HasColumnType("text")
                        .HasColumnName("create_by");

                    b.Property<string>("Deleted")
                        .HasColumnType("text")
                        .HasColumnName("deleted");

                    b.Property<DateTime?>("FromDate")
                        .HasColumnType("datetime")
                        .HasColumnName("from_date");

                    b.Property<double?>("MaxDiscountPrice")
                        .HasColumnType("double")
                        .HasColumnName("max_discount_price");

                    b.Property<int?>("PercentDiscount")
                        .HasColumnType("int")
                        .HasColumnName("percent_discount");

                    b.Property<DateTime?>("ToDate")
                        .HasColumnType("datetime")
                        .HasColumnName("to_date");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime")
                        .HasColumnName("update_at");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("text")
                        .HasColumnName("update_by");

                    b.Property<byte[]>("Uuid")
                        .IsRequired()
                        .HasColumnType("varbinary(16)")
                        .HasColumnName("uuid");

                    b.HasKey("Id")
                        .HasName("pk_sale");

                    b.HasIndex("Id")
                        .HasDatabaseName("ix_sale_id");

                    b.ToTable("sale");
                });

            modelBuilder.Entity("App.Models.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(767)")
                        .HasColumnName("id");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int")
                        .HasColumnName("access_failed_count");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text")
                        .HasColumnName("concurrency_stamp");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("email");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("email_confirmed");

                    b.Property<string>("FullName")
                        .HasColumnType("text")
                        .HasColumnName("full_name");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("lockout_enabled");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp")
                        .HasColumnName("lockout_end");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("normalized_email");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("normalized_user_name");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text")
                        .HasColumnName("password_hash");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("phone_number_confirmed");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text")
                        .HasColumnName("security_stamp");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("two_factor_enabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("user_name");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(767)")
                        .HasColumnName("id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text")
                        .HasColumnName("concurrency_stamp");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("name");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("normalized_name");

                    b.HasKey("Id")
                        .HasName("pk_roles");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("ClaimType")
                        .HasColumnType("text")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text")
                        .HasColumnName("claim_value");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(767)")
                        .HasColumnName("role_id");

                    b.HasKey("Id")
                        .HasName("pk_role_claims");

                    b.HasIndex("RoleId")
                        .HasDatabaseName("ix_role_claims_role_id");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("ClaimType")
                        .HasColumnType("text")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text")
                        .HasColumnName("claim_value");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(767)")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_user_claims");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_user_claims_user_id");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(767)")
                        .HasColumnName("login_provider");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(767)")
                        .HasColumnName("provider_key");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text")
                        .HasColumnName("provider_display_name");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(767)")
                        .HasColumnName("user_id");

                    b.HasKey("LoginProvider", "ProviderKey")
                        .HasName("pk_user_logins");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_user_logins_user_id");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(767)")
                        .HasColumnName("user_id");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(767)")
                        .HasColumnName("role_id");

                    b.HasKey("UserId", "RoleId")
                        .HasName("pk_user_roles");

                    b.HasIndex("RoleId")
                        .HasDatabaseName("ix_user_roles_role_id");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(767)")
                        .HasColumnName("user_id");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(767)")
                        .HasColumnName("login_provider");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(767)")
                        .HasColumnName("name");

                    b.Property<string>("Value")
                        .HasColumnType("text")
                        .HasColumnName("value");

                    b.HasKey("UserId", "LoginProvider", "Name")
                        .HasName("pk_user_tokens");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("App.Models.Entities.Bill", b =>
                {
                    b.HasOne("App.Models.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("fk_bills_customers_customer_id");

                    b.HasOne("App.Models.Entities.User", "UserPayment")
                        .WithMany()
                        .HasForeignKey("UserPaymentId")
                        .HasConstraintName("fk_bills_users_user_payment_id");

                    b.Navigation("Customer");

                    b.Navigation("UserPayment");
                });

            modelBuilder.Entity("App.Models.Entities.BillDetail", b =>
                {
                    b.HasOne("App.Models.Entities.Bill", "Bill")
                        .WithMany()
                        .HasForeignKey("BillId")
                        .HasConstraintName("fk_bill_details_bills_bill_id");

                    b.HasOne("App.Models.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .HasConstraintName("fk_bill_details_products_product_id");

                    b.Navigation("Bill");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("App.Models.Entities.Category", b =>
                {
                    b.HasOne("App.Models.Entities.Category", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId")
                        .HasConstraintName("fk_categories_categories_parent_id");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("App.Models.Entities.CategoryDetail", b =>
                {
                    b.HasOne("App.Models.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("fk_category_details_categories_category_id");

                    b.HasOne("App.Models.Entities.Lang", "Lang")
                        .WithMany()
                        .HasForeignKey("LangId")
                        .HasConstraintName("fk_category_details_langs_lang_id");

                    b.Navigation("Category");

                    b.Navigation("Lang");
                });

            modelBuilder.Entity("App.Models.Entities.Product", b =>
                {
                    b.HasOne("App.Models.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("fk_products_categories_category_id");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("App.Models.Entities.ProductDetail", b =>
                {
                    b.HasOne("App.Models.Entities.Lang", "Lang")
                        .WithMany()
                        .HasForeignKey("LangId")
                        .HasConstraintName("fk_product_details_langs_lang_id");

                    b.HasOne("App.Models.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .HasConstraintName("fk_product_details_products_product_id");

                    b.Navigation("Lang");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("fk_role_claims_asp_net_roles_identity_role_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("App.Models.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_user_claims_asp_net_users_user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("App.Models.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_user_logins_asp_net_users_user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("fk_user_roles_asp_net_roles_identity_role_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Models.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_user_roles_asp_net_users_user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("App.Models.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_user_tokens_asp_net_users_user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
