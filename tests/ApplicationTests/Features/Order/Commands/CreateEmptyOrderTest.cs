using Serivce.Features.Orders.Commands.CreateEmptyOrder;
using ApplicationTests.Common;
using Domain.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ApplicationTests.Features.Order.Commands
{
    public class CreateEmptyOrderTest : TestCommandBase
    {
        const string user1ID = "0f67cf57-aaa9-4a6a-adff-baaa20e3a8b1";

        [Theory]
        [InlineData(user1ID)]
        public async Task CreateEmptyOrder_EmptyOrder(string userId)
        {
            var handler = new CreateEmptyOrderHandler(Context);
            var orderId = await handler.Handle(
                new CreateEmptyOrderCommand
                {
                    UserId = userId
                },
                CancellationToken.None);

            var result = Context.Orders.Where(u => u.CreatedBy == Guid.Parse(userId)).FirstOrDefault();
            Assert.Equal(result.CreatedBy.ToString(), userId);
        }
    }
}
