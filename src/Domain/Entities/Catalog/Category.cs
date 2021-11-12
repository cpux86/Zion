using Ardalis.GuardClauses;
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

        public long Id { get; set; }
        public string Name { get; private set; }
        /// <summary>
        /// последняя секция URL
        /// </summary>
        public string Path { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// Родительская категория
        /// </summary>
        public Category Parent { get; set; }
        // дочерние категории
        public List<Category> Childrens { get; private set; } = new List<Category>();
        // Заказы. Запрос на приобретение товара, содержащий описание товара
        public List<Order> Orders { get; private set; } = new List<Order>();
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
        /// <param name="children">Новая категория</param>
        public void AddCategory(Category children)
        {
            //try
            //{
            //    var s = Guard.Against.NullOrWhiteSpace(children.Name, nameof(children.Name));
            //}
            //catch (Exception e)
            //{

            //    throw;
            //}
            
            //var ch = children.Name.Trim();

            // проверка на конфилкт имен категорий. не допускаем наличии категорий с одинаковым именем
            if (Childrens.Where(c=>c.Name.Equals(children.Name.Trim(), StringComparison.CurrentCultureIgnoreCase))
                .Any()) throw new Exception(Name);
            // есили новая категория с уникльным именем, то добавляем ее в коллекцию
            Childrens.Add(children);

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
