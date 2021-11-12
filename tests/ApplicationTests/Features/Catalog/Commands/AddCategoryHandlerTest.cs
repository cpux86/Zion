using Application.Features.Catalog.Commands.AddCategory;
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
    public class AddCategoryHandlerTest : TestCommandBase
    {
        [Theory]
        [InlineData("HD", 1)]
        public async Task AddCategory_Id(string name, long parentId)
        {
            var handler = new AddCategoryHandler(Context);
            var categoryId = await handler.Handle(
                new AddCategoryCommand 
                {
                    Name = name,
                    CategoryParent = parentId
                },
                CancellationToken.None);
        }
    }
}
