using Ardalis.GuardClauses;
using Domain.Common;
using Domain.Entities.OrderAggregate;
using Domain.Entities.ProductAggregate;
using Domain.Utils;
using NickBuhro.Translit;
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
        public string Slug { get; set; }
        //public long ParentId { get; set; }
        /// <summary>
        /// Родительская категория
        /// </summary>
        public Category Parent { get; set; }
        /// <summary>
        /// Коллекция всех предков категории 
        /// </summary>
        public List<Category> Ancestors { get; private set; } = new List<Category>();
        public List<Category> Nodes { get; set; } = new List<Category>();
        // дочерние категории
        public virtual List<Category> Childrens { get; private set; } = new List<Category>();
        // Заказы. Запрос на приобретение товара, содержащий описание товара
        public virtual List<Order> Orders { get; private set; } = new List<Order>();
        // товары которые уже имеются в категории
        public virtual List<Product> Products { get; private set; } = new List<Product>();

        /// <summary>
        /// Добавить подкатегорию
        /// </summary>
        /// <param name="children">Новая категория</param>
        public void AddCategory(Category children)
        {
            // проверка на конфилкт имен категорий. не допускаем наличии категорий с одинаковым именем
            if (Childrens.Where(c => c.Name.Equals(children.Name.Trim(), StringComparison.CurrentCultureIgnoreCase))
                .Any()) throw new Exception(Name);

            // создаю slug для новой категории из ее имени
            string slug = SlugGenerator.ToUrlSlug(children.Name);
            children.Slug = slug;

            // текущая категория является родителем для новой категории
            children.Parent = this;

            // создаю ссылку между категориями-предками и новай категорией
            // каждая категория-предок имеет ссылку на все вложенные категории и подкатегории
            Ancestors.ForEach(e => e.Childrens.Add(children));

            // есили новая категория с уникльным именем, то добавляем ее в коллекцию
            Childrens.Add(children);
            Nodes.Add(children);


            //try
            //{
            //    var s = Guard.Against.NullOrWhiteSpace(children.Name, nameof(children.Name));
            //}
            //catch (Exception e)
            //{

            //    throw;
            //}
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
