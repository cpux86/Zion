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
        [InlineData("Электроника", 1)]
        [InlineData("Телевизоры", 2)]
        [InlineData("Мобильные телефоны", 2)]
        [InlineData("UHD", 3)]
        [InlineData("Sony", 4)]
        [InlineData("Samsung", 4)]
        [InlineData("Iphone", 4)]
        [InlineData("Sony1.1", 6)]
        [InlineData("Sony1.1.1", 9)]
        public async Task AddCategory_Id(string name, long parentId)
        {
            var handler = new AddCategoryHandler(Context);
            var categoryId = await handler.Handle(
                new AddCategoryCommand 
                {
                    Name = name,
                    ParentId = parentId
                },
                CancellationToken.None);
        }
    }
}
