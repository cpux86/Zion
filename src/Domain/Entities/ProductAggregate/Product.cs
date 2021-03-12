using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.ProductAggregate
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public List<Properties> Properties { get; set; }
    }
}
