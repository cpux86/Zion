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
            // подгружаю все категории в контекст
            await _catalogContext.Categories.ToListAsync(cancellationToken);

            Category result = _catalogContext.Categories
                .Where(e => e.Name == "Root")
                .FirstOrDefault();

            return new MenuViewModele { Menu = result.Childrens };
        }
    }
}
