using ImageProcessingService.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace ImageProcessingService.Infrastructure
{
    public class ImageContext : DbContext
    {
        public DbSet<FileImage> FileImages { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder
                //.UseSqlite(@"DataSource=./wwwroot/Images.db");
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=zion;Username=postgres;Password=1AC290066F");
                //optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("ConnectionString"));
            }

            optionsBuilder.LogTo(message => System.Diagnostics.Debug.WriteLine(message));

        }
    }
}
