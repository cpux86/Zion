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
        public IEnumerable<Category> Menu { get; set; }
    }
}
