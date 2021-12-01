﻿using Application.Interfaces;
using Domain.Entities;
using Domain.Entities.Catalog;
using Domain.Entities.OrderAggregate;
using Domain.Entities.ProductAggregate;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Persistence.Config;
using System;


namespace Persistence.Context
{
    public class CatalogContext : DbContext, ICatalogContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Published> Publisheds { get; set; }
        public CatalogContext() { }
        public CatalogContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                .UseSqlite(@"DataSource=C:\C#\Zion\DB\Zion.db");
            }

            optionsBuilder.LogTo(message => System.Diagnostics.Debug.WriteLine(message));

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CategoryConfiguration());
        }
    }
}
