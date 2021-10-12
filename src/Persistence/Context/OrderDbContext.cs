using Application.Interfaces;
using Domain.Entities;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistence.Context
{
    public class OrderDbContext : DbContext, IOrderDbContext
    {
        public DbSet<Order> Orders { get; set; }
        public OrderDbContext([NotNull] DbContextOptions options) : base(options) { }
    }
}
