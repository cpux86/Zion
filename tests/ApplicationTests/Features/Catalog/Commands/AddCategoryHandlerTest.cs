using Application.Features.Catalog.Commands.AddCategory;
using Application.Features.Catalog.Commands.DeleteCategory;
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
        [InlineData("Sony", 5)]
        [InlineData("Samsung", 5)]
        [InlineData("Sony1.1", 7)]
        [InlineData("Sony1.1.1", 8)]
        [InlineData("Sony1.1.1.1", 9)]
        [InlineData("iPhone", 4)]
        //[InlineData("Транспорт", 1)]
        //[InlineData("Легковой", 2)]
        //[InlineData("Грузовой", 2)]
        public async Task AddCategory_Id(string name, long parentId)
        {

            var handler = new AddCategoryHandler(Context);
            long categoryId = await handler.Handle(
                new AddCategoryCommand 
                {
                    Name = name,
                    ParentId = parentId
                },
                CancellationToken.None);
            Assert.True(categoryId > 0);
        }

    }
}
