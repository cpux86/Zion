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
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace Application.Features.Catalog.Queries.GetCategoriesList
{
    public class GetCategoriesListQueryHandler : IRequestHandler<GetCategoriesListQuery, MenuViewModele>
    {
        private readonly ICatalogContext _catalogContext;
        private readonly IMapper _mapper;

        public GetCategoriesListQueryHandler(ICatalogContext catalogContext, IMapper mapper)
        {
            _catalogContext = catalogContext;
            _mapper = mapper;
        }

        public async Task<MenuViewModele> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
        {
            // подгружаю все категории в контекст
            var allMunuList = await _catalogContext.Categories
                //.Include(e => e.Childrens)
                .ToListAsync(cancellationToken);
           //var  w = wm.FirstOrDefault();

            //Category wm = await _catalogContext.Categories
            //    .Where(e => e.Name == "Root")
            //    .FirstOrDefaultAsync();
            var res = _mapper.Map<MenuViewModele>(allMunuList.FirstOrDefault());
            return res;
        }
    }
}
