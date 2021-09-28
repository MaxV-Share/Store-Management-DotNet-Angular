using App.Models.Entities.Identities;
using App.Models.Entities;
using MaxV.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace App.Infrastructures.Dbcontexts
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, string, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        private readonly IConfiguration _configuration;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        public virtual DbSet<Bill> Bills { set; get; }
        public virtual DbSet<BillDetail> BillDetails { set; get; }
        public virtual DbSet<Category> Categories { set; get; }
        public virtual DbSet<CategoryDetail> CategoryDetails { set; get; }
        public virtual DbSet<Product> Products { set; get; }
        public virtual DbSet<ProductDetail> ProductDetails { set; get; }
        public virtual DbSet<Customer> Customers { set; get; }
        public virtual DbSet<Discount> Discounts { set; get; }
        public virtual DbSet<Lang> Langs { set; get; }
        public virtual DbSet<Permission> Permissions { set; get; }
        public virtual DbSet<Command> Commands { set; get; }
        public virtual DbSet<Function> Functions { set; get; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Bill>().HasQueryFilter(p => p.Deleted == null);

            builder.Entity<BillDetail>().HasQueryFilter(p => p.Deleted == null);

            builder.Entity<Category>().HasQueryFilter(p => p.Deleted == null);

            builder.Entity<CategoryDetail>().HasQueryFilter(p => p.Deleted == null);

            builder.Entity<Product>().HasQueryFilter(p => p.Deleted == null);

            builder.Entity<ProductDetail>().HasQueryFilter(p => p.Deleted == null);

            builder.Entity<Customer>().HasQueryFilter(p => p.Deleted == null);

            builder.Entity<Discount>().HasQueryFilter(p => p.Deleted == null);

            builder.Entity<Lang>().HasQueryFilter(p => p.Deleted == null);
            builder.Entity<Lang>().Property(e => e.Id).HasMaxLength(256);

            builder.Entity<Permission>().HasQueryFilter(p => p.Deleted == null);

            builder.Entity<Command>().HasQueryFilter(p => p.Deleted == null);

            builder.Entity<Function>().HasQueryFilter(p => p.Deleted == null);

            builder.Entity<User>()
                .HasMany(e => e.UserRoles)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<UserRole>()
                .HasOne(e => e.User)
                .WithMany(e => e.UserRoles)
                .HasForeignKey(e => e.UserId);

            builder.Entity<UserRole>()
                .HasOne(e => e.Role)
                .WithMany(e => e.UserRoles)
                .HasForeignKey(e => e.RoleId);

            builder.Entity<UserClaim>()
                .HasOne(e => e.User)
                .WithMany(e => e.UserClaims).HasForeignKey(e => e.UserId);

            builder.Entity<RoleClaim>()
                .HasOne(e => e.Role)
                .WithMany(e => e.RoleClaims).HasForeignKey(e => e.RoleId);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Method intentionally left empty.
            //optionsBuilder.UseLazyLoadingProxies();
            //optionsBuilder.ConfigureWarnings(w => w.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning));
        }
    }
}
