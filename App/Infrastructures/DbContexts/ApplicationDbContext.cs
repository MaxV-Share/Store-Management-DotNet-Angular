using App.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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
        public virtual DbSet<Sale> Sale { set; get; }
        public virtual DbSet<Lang> Langs { set; get; }
        public virtual DbSet<CategoryDetail> CategoryDetails { set; get; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.HasSequence<int>("SEQ_SALSE_ID", schema: "SCHEMA")
            //.StartsAt(1)
            //.IncrementsBy(1);
            modelBuilder.Entity<Sale>().Property(e => e.Id).ValueGeneratedOnAdd();

            //modelBuilder.HasSequence<int>("SEQ_BillDetail_ID", schema: "SCHEMA")
            //.StartsAt(1)
            //.IncrementsBy(1);
            //modelBuilder.Entity<BillDetail>().HasIndex(e => new { e.Id, e.Bill });
            //modelBuilder.Entity<BillDetail>().Property(e => e.Id).HasDefaultValueSql("NEXT VALUE FOR shared.OrderNumbers");

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
    }
}
