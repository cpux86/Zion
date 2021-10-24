using Domain.Common;
using Domain.Entities.ProductAggregate;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class ProductCatalog
    {
        public ProductCatalog(string name)
        {
            Name = name;
            Items = new List<ProductCatalog>();
        }

        private ProductCatalog()
        {
            // Требуется для EF
        }
        public Guid Guid { get; set; }
        public string Name { get; private set; }
        public string Description { get; set; }
        // дочерние категории
        public List<ProductCatalog> Items { get; private set; }
        public List<Product> Products { get; private set; } = new List<Product>();
        public List<Properties> Properties { get; private set; }
        /// <summary>
        /// Добавить описание категории
        /// </summary>
        //public void AddDescriptionCategory(string description) 
        //{
        //    Description = description;
        //}

        /// <summary>
        /// Добавить подкатегорию
        /// </summary>
        /// <param name="item"></param>
        public void AddCategoryItem(ProductCatalog item)
        {
            Items.Add(item);
        }
        /// <summary>
        /// Добавить продукт в категорию
        /// </summary>
        /// <param name="product"></param>
        public void AddProduct(Product product)
        {
            Products.Add(product);
        }
    }
}
