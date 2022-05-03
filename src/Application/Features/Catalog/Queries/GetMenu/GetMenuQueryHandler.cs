using Serivce.Interfaces;
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

namespace Serivce.Features.Catalog.Queries.GetMenu
{
    public class GetMenuQueryHandler : IRequestHandler<GetMenuQuery, List<MenuViewModele>>
    {
        private readonly ICatalogContext _catalogContext;
        private readonly IMapper _mapper;

        public GetMenuQueryHandler(ICatalogContext catalogContext, IMapper mapper)
        {
            _catalogContext = catalogContext;
            _mapper = mapper;
        }

        public async Task<List<MenuViewModele>> Handle(GetMenuQuery request, CancellationToken cancellationToken)
        {
            // подгружаю все категории в контекст
            var allMunuList = await _catalogContext.Categories
                .ToListAsync(cancellationToken);
            
            foreach (var item in allMunuList)
            {
                item.Slug = item.Parent == null ? $"/{item.Slug}-{item.Id}" : $"{item.Parent.Slug}/{item.Slug}-{item.Id}";

                //if (item.Parent != null)
                //{
                //    item.Slug = $"{item.Parent.Slug}-{item.Parent.Id}/{item.Slug}";
                //}

            }

            var root = _catalogContext.Categories.Where(c => c.Lavel == 0).ToList();
            root.ForEach(c=>Console.WriteLine(c.Name));

            List<MenuViewModele> menuViewModele = new List<MenuViewModele>();

            root.ForEach(c => menuViewModele.Add(_mapper.Map<MenuViewModele>(c)));

            //foreach (var item in root)
            //{
            //    menuViewModele.Add(_mapper.Map<MenuViewModele>(item));
            //}

            //var menuVm = _mapper.Map<MenuVm>(menuViewModele.FirstOrDefault());
            return menuViewModele;
        }
    }
}
