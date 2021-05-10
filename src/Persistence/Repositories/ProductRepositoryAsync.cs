using Domain.Entities.ProductAggregate;
using Domain.Interfaces.Repositories;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Repositories
{
    public class ProductRepositoryAsync : GenericRepositoryAsync<Product, int>, IProductRepositoryAsync
    {
        public ProductRepositoryAsync(CatalogContext catalogContext) : base(catalogContext)
        {
            
        }
    }
}
