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

namespace Application.Features.Catalog.Queries.GetMenu
{
    public class GetMenuQueryHandler : IRequestHandler<GetMenuQuery, MenuVm>
    {
        private readonly ICatalogContext _catalogContext;
        private readonly IMapper _mapper;

        public GetMenuQueryHandler(ICatalogContext catalogContext, IMapper mapper)
        {
            _catalogContext = catalogContext;
            _mapper = mapper;
        }

        public async Task<MenuVm> Handle(GetMenuQuery request, CancellationToken cancellationToken)
        {
            // подгружаю все категории в контекст
            var allMunuList = await _catalogContext.Categories
                .ToListAsync(cancellationToken);
            var menuViewModele = _mapper.Map<MenuViewModele>(allMunuList.FirstOrDefault());
            var menuVm = _mapper.Map<MenuVm>(menuViewModele);
            return menuVm;
        }
    }
}
