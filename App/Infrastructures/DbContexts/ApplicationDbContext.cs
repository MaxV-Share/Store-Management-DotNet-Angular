using App.Models.Entities;
using MaxV.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        private readonly IConfiguration _configuration;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        public virtual DbSet<Bill> Bills { set; get; }
        public virtual DbSet<BillDetail> BillDetails { set; get; }
        public virtual DbSet<Category> Categories { set; get; }
        public virtual DbSet<Customer> Customers { set; get; }
        public virtual DbSet<Product> Products { set; get; }
        public virtual DbSet<Discount> Discounts { set; get; }
        public virtual DbSet<Lang> Langs { set; get; }
        public virtual DbSet<CategoryDetail> CategoryDetails { set; get; }
        public virtual DbSet<ProductDetail> ProductDetails { set; get; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Bill>().HasQueryFilter(p => p.Deleted == null);
            builder.Entity<BillDetail>().HasQueryFilter(p => p.Deleted == null);
            builder.Entity<Category>().HasQueryFilter(p => p.Deleted == null);
            builder.Entity<Customer>().HasQueryFilter(p => p.Deleted == null);
            builder.Entity<Product>().HasQueryFilter(p => p.Deleted == null);
            builder.Entity<Discount>().HasQueryFilter(p => p.Deleted == null);
            builder.Entity<Lang>().HasQueryFilter(p => p.Deleted == null);
            builder.Entity<CategoryDetail>().HasQueryFilter(p => p.Deleted == null);
            builder.Entity<ProductDetail>().HasQueryFilter(p => p.Deleted == null);

            builder.Entity<Discount>().Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Entity<Lang>().Property(e => e.Id).HasMaxLength(256);


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Method intentionally left empty.
            //optionsBuilder.UseLazyLoadingProxies();
            //optionsBuilder.ConfigureWarnings(w => w.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning));
        }
    }
}
