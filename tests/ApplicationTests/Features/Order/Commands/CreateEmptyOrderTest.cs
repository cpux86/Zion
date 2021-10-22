﻿using Application.Features.Orders.Commands.CreateEmptyOrder;
using ApplicationTests.Common;
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
        [Theory]
        [InlineData("0f67cf57-aaa9-4a6a-adff-baaa20e3a8b1")]
        public async Task CreateEmptyOrder_EmptyOrder(string userId)
        {
            var handler = new CreateEmptyOrderHandler(Context);
            await handler.Handle(
                new CreateEmptyOrderCommand
                {
                    UserId = userId
                },
                CancellationToken.None);
            var result = Context.Orders.Where(u => u.CreatedBy == userId).FirstOrDefault();
            Assert.Equal(result.CreatedBy, userId);
        }
    }
}
