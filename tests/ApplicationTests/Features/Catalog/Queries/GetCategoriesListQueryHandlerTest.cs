using Application.Features.Catalog.Queries.GetCategoriesList;
using ApplicationTests.Common;
using Domain.Entities.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ApplicationTests.Features.Catalog.Queries
{
    public class GetCategoriesListQueryHandlerTest : TestCommandBase
    {
        [Fact]
        public async Task GetMenu_Menu()
        {
            var handler = new GetCategoriesListQueryHandler(Context);
            MenuViewModele menu = await handler.Handle(new GetCategoriesListQuery(), CancellationToken.None);
            //
            Assert.True(menu.Menu.Count() > 0);
        }
    }
}
