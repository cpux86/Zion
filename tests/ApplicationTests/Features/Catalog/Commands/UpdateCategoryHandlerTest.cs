using Application.Features.Catalog.Commands.UpdateCategory;
using ApplicationTests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ApplicationTests.Features.Catalog.Commands
{
    public class UpdateCategoryHandlerTest : TestCommandBase
    {
        [Theory]
        [InlineData(5, "Телевизоры")]
        public async void UpdateCategory(long id, string name)
        {
            var handler = new UpdateCategoryHandler(Context);
            await handler.Handle(
                new UpdateCategoryCommand 
                { 
                    Id = id,
                    Name = name
                },
                CancellationToken.None
                );
        }
    }
}
