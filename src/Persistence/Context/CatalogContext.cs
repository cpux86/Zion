using Application.Interfaces;
using Domain.Entities;
using Domain.Entities.ProductAggregate;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;


namespace Persistence.Context
{
    public class CatalogContext : DbContext, ICatalogContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Properties> Properties { get; set; }

        public CatalogContext([NotNull] DbContextOptions options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder
        //        .UseSqlite("DataSource=Dmd.db");
        //    }

        //}
        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
    }
}
