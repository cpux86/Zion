using Domain.Common;
using Domain.Entities.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Category : AggregateRoot<int>
    {
        public Category(string name)
        {
            Name = name;
            Items = new List<Category>();
        }

        private Category()
        {
            // Требуется для EF
        }

        public string Name { get; private set; }
        public string Description { get; set; }
        // дочерние категории
        public List<Category> Items { get; private set; }
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
        public void AddCategoryItem(Category item)
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
