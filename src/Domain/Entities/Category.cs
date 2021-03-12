using Domain.Entities.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Category Items { get; set; }
        public List<Product> Products { get; set; }
        public List<Properties> Properties { get; set; }
    }
}
