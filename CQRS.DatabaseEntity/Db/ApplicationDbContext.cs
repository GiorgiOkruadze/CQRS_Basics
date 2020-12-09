using System;
using System.Collections.Generic;
using System.Text;
using CQRS.DomainModels.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS.DatabaseEntity.Db
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Reseller> Reseller { get; set; }
        public DbSet<Volume> Volume { get; set; }

        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=GIORGIOKRUADZE;Database=CQRS;Trusted_Connection=true;MultipleActiveResultSets=true;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProductReseller>()
                .HasKey(o => new { ProductId = o.ProductId, ResellerId = o.ResellerId });
        }
    }
}
