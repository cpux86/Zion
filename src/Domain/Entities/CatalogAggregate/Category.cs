using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.CatalogAggregate
{
    public class Category : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; set; }
        // это может быть каталог с заказами или с предложениями
        public Type Type { get; private set; }
    }
}
