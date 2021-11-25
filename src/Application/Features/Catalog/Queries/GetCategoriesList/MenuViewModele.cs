using Domain.Entities.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Catalog.Queries.GetCategoriesList
{
    public class MenuViewModele
    {
        public string Name { get; set; }
        public IEnumerable<Category> Childrens { get; set; }
    }
}
