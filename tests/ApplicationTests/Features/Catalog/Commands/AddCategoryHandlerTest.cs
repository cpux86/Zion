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
        [InlineData("UHD", "ADEDBB95-18CF-432B-B7EE-D41F99C5521C")]
        public async Task AddCategory_Id(string name, string parent)
        {
            var handler = new AddCategoryHandler(Context);
            var categoryId = await handler.Handle(
                new AddCategoryCommand 
                {
                    Name = name,
                    CategoryParent = parent
                },
                CancellationToken.None);
        }
    }
}
