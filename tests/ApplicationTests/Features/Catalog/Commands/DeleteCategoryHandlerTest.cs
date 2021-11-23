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
    public class DeleteCategoryHandlerTest : TestCommandBase
    {
        [Theory]
        //[InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        [InlineData(11)]
        public async Task DeleteCategoryById(long categoryId)
        {
            var handler = new DeleteCategoryHandler(Context);
            bool status = await handler.Handle(
                new DeleteCategoryCommand
                {
                    Id = categoryId
                },
                CancellationToken.None);
            Assert.True(status);
        }
    }
}
