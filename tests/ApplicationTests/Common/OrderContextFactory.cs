using Domain.Entities;
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
        public static OrderDbContext Create()
        {
            var options = new DbContextOptionsBuilder<OrderDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new OrderDbContext(options);
            context.Orders.AddRange(
                new Order
                {
                    Title = "Микросхема ШИМ-контроллера",
                    Comments = "Шим-контроллер с частоного преобразователя Siemens",
                    ProductImagesURLs = new List<string>
                    {
                        "https//zion.ru/images/1.jpg",
                        "https//zion.ru/images/2.jpg"
                    }

                }
                );


            context.SaveChanges();
            return context;
        }
    }
}
