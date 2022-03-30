using Domain.Entities.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serivce.Features.Catalog.Queries.GetMenu
{
    public class MenuViewModele
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Url { get; set; }
        public IEnumerable<MenuViewModele> Categories { get; set; }
    }
    public class MenuVm
    {
        public IEnumerable<MenuViewModele> Categories { get; set; }
    }
}
