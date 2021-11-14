using Domain.Entities.Catalog;
using Domain.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ApplicationTests.Common
{
    public class OrderContextFactory
    {
        const string User1 = "295005a2-9b2a-400a-a85b-87c08719b40a";
        const string User2 = "295005a2-9b2a-400a-a85b-87c08719baaa";


        public static CatalogContext Create()
        {
            //var options = new DbContextOptionsBuilder<OrderDbContext>()
            //    .UseInMemoryDatabase(Guid.NewGuid().ToString())
            //    .Options;


            var options = new DbContextOptionsBuilder<CatalogContext>()
            .UseSqlite(@"DataSource=C:\C#\Zion\DB\Zion.db").Options;


            var context = new CatalogContext(options);
            //context.Database.EnsureCreated();
            context.Orders.AddRange(

                new Order(User1,DateTimeOffset.UtcNow).Update(
                    "Микросхема №1 ШИМ-контроллера",
                    "Шим-контроллер с частоного преобразователя Siemens",
                    DateTimeOffset.UtcNow),
                new Order(User1, DateTimeOffset.UtcNow).Update(
                    "Микросхема №2 ШИМ-контроллера",
                    "Шим-контроллер с частоного преобразователя Siemens",
                    DateTimeOffset.UtcNow),
                new Order(User1, DateTimeOffset.UtcNow).Update(
                    "Микросхема №3 ШИМ-контроллера",
                    "Шим-контроллер с частоного преобразователя Siemens",
                    DateTimeOffset.UtcNow)
                );


            context.SaveChangesAsync();


            //List<Guid> gStr = new List<Guid>();
            //gStr.Add(Guid.Parse("4C063222-7EDE-4EFF-A792-84C4F296DA0D"));
            //gStr.Add(Guid.Parse("8118CEF9-1CC3-469A-B500-4435657A416D"));
            //gStr.Add(Guid.Parse("94F85337-BB02-4E0C-8663-0C1270EC5A5F"));
            //var result = context.Orders.Where(o => gStr.Contains(o.Id)).Select(e => new { e.Title, e.Id }).ToList();

            var res = context.Categories.Where(c => c.Id == 2)
                .Include(c => c.Childrens)
                .ThenInclude(c => c.Childrens).FirstOrDefault();



            return context;
        }
    }
}
