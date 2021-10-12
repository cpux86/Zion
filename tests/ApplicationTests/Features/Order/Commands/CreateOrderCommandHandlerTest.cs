using Application.Features.Orders.Commands.CreateOrder;
using Application.Interfaces;
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
    public class CreateOrderCommandHandlerTest : TestCommandBase
    {

        [Theory]
        [InlineData(
            "Микросхема ШИМ-контроллера",
            "Шим-контроллер с частоного преобразователя Siemens",
            new string[] { "https//zion.ru/images/1.jpg", "https//zion.ru/images/2.jpg" })]
        public async Task CreateOrder_Success(string title, string comment, string[] images)
        {
            var handler = new CreateOrderCommandHandler(Context);
            var orderId =await  handler.Handle(
                new CreateOrderCommand { 
                    Title = title,
                    Comments = comment,
                    ProductImagesURLs = images
                },
                CancellationToken.None);
            
        }

    }
}
