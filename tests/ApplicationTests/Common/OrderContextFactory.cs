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
                    ImageSource = "https//zion.ru/images/1.jpg",
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = User1
                }
                );


            context.SaveChanges();
            return context;
        }
    }
}
