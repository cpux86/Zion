using Application.Features.Catalog.Queries.GetCategoriesList;
using ApplicationTests.Common;
using AutoMapper;
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
        private readonly IMapper _mapper;
        [Fact]
        public async Task GetMenu_Menu()
        {
            var handler = new GetCategoriesListQueryHandler(Context, _mapper);
            MenuViewModele menu = await handler.Handle(new GetCategoriesListQuery(), CancellationToken.None);
            //
            //Assert.True(menu.Menu.Count() > 0);
        }
    }
}
