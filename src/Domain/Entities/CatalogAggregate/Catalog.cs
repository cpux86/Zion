using Domain.Common;
using Domain.Entities.ProductAggregate;
using System;
using System.Collections.Generic;

namespace Domain.Entities.CatalogAggregate
{
    public class Catalog : BaseEntity
    {
        public Catalog(string name)
        {

        }

        private Catalog()
        {
            // Требуется для EF
        }
        // дочерние категории
        public List<Category> Categories { get; private set; }
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
        /// <param name="node">родительская категория</param>
        public void AddCategory(Category parent)
        {
            Categories.Add(parent);
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
