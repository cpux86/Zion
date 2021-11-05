using Domain.Common;
using Domain.Entities.OrderAggregate;
using Domain.Entities.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities.Catalog
{
    public class Category
    {

        private Category()
        {
            // Требуется для EF
        }

        public Category(string name)
        {
            Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; private set; }
        public string Description { get; set; }
        /// <summary>
        /// Родительская категория
        /// </summary>
        public Category Parent { get; set; }
        // дочерние категории
        public List<Category> Items { get; private set; }
        // Заказы. Запрос на приобретение товара, содержащий описание товара
        public List<Order> Orders { get; private set; }
        // товары которые уже имеются в категории
        public List<Product> Products { get; private set; } = new List<Product>();
        /// <summary>
        /// Добавить описание категории
        /// </summary>
        public void AddDescriptionCategory(string description)
        {
            Description = description;
        }

        /// <summary>
        /// Добавить подкатегорию
        /// </summary>
        /// <param name="item">Новая категория</param>
        public void AddCategory(Category item)
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
