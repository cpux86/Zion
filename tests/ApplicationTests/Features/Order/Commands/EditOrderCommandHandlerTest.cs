using Application.Features.Orders.Commands.EditOrder;
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
    public class EditOrderCommandHandlerTest : TestCommandBase
    {
        [Theory]
        [InlineData(
            "0f67cf57-aaa9-4a6a-adff-baaa20e3a8b1",
            "Микросхема ШИМ-контроллера # 0",
            "Шим-контроллер с частоного преобразователя Siemens",
            "https//zion.ru/images/1.jpg")]
        public async Task EditOrder_Success(string orderId, string title, string comment, string images)
        {
            var handler = new EditOrderCommandHandler(Context);
            await handler.Handle(
                new EditOrderCommand
                {
                    OrderId = orderId,
                    Title = title,
                    Comments = comment,
                    ImageSource = images
                },
                CancellationToken.None);
        }

    }
}
