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
using Service.Interfaces;

namespace Service.Features.Catalog.Queries.GetMenu
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
            // подгружаю все категории меню в контекст, не зависимо от того, целиком или определенную часть меню мы хотим получить.
            var allMenuList = await _catalogContext.Categories
                .ToListAsync(cancellationToken);


            //foreach (var item in allMenuList)
            //{
            //    // url вида category_name-category_id/sub_category_name-category_id/
            //    //item.Slug = item.Parent == null ? $"/{item.Slug}-{item.Id}" : $"{item.Parent.Slug}/{item.Slug}-{item.Id}";

            //    item.Slug = $"/{item.Slug}-{item.Id}";


            //    //if (item.Parent != null)
            //    //{
            //    //    item.Slug = $"{item.Parent.Slug}-{item.Parent.Id}/{item.Slug}";
            //    //}

            //}

            // видоизменяю Slug в каждом пункте меню, пока оно имеет плоский вид. После выборки изменить slug таким образом не получилось.
            allMenuList.ForEach(c => c.Slug = $"/{c.Slug}-{c.Id}");


            // выбираю все меню
            var root = allMenuList.Where(c => c.Parent == null).ToList();

            // получаем определенную ветвь меню
            //var root = await _catalogContext.Categories.Where(c => c.Parent.Id == 22).ToListAsync(cancellationToken);


            //foreach (var item in root)
            //{
            //    // url вида category_name-category_id/sub_category_name-category_id/
            //    //item.Slug = item.Parent == null ? $"/{item.Slug}-{item.Id}" : $"{item.Parent.Slug}/{item.Slug}-{item.Id}";

            //    //item.Slug = $"/{item.Slug}-{item.Id}";

            //}

            

            //root.ForEach(c=>Console.WriteLine(c.Name));

            List<MenuViewModele> menuViewModel = new List<MenuViewModele>();

            root.ForEach(c => menuViewModel.Add(_mapper.Map<MenuViewModele>(c)));

            //foreach (var item in root)
            //{
            //    menuViewModele.Add(_mapper.Map<MenuViewModele>(item));
            //}

            //var menuVm = _mapper.Map<MenuVm>(menuViewModele.FirstOrDefault());
            return menuViewModel;
        }
    }
}
