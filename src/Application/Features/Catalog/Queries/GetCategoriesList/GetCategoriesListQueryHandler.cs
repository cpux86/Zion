using Application.Interfaces;
using Domain.Entities.Catalog;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Catalog.Queries.GetCategoriesList
{
    public class GetCategoriesListQueryHandler : IRequestHandler<GetCategoriesListQuery, MenuViewModele>
    {
        private readonly ICatalogContext _catalogContext;

        public GetCategoriesListQueryHandler(ICatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }

        public async Task<MenuViewModele> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
        {
            Category res = await _catalogContext.Categories
                .Where(c => c.Id == 1)
                .Include(c => c.Childrens)
                .FirstOrDefaultAsync();
            return new MenuViewModele { Menu = res };
        }
    }
}
