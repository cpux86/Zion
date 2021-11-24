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
        public string Slug { get; private set; }
        
        /// <summary>
        /// Родительская категория
        /// </summary>
        public Category Parent { get; set; }

        // дочерние категории
        public virtual List<Category> Childrens { get; private set; } = new List<Category>();
        // Заказы. Запрос на приобретение товара, содержащий описание товара
        public virtual List<Order> Orders { get; private set; } = new List<Order>();
        // товары которые уже имеются в категории
        public virtual List<Product> Products { get; private set; } = new List<Product>();

        #region CRUD v1
        /// <summary>
        /// Добавить подкатегорию
        /// </summary>
        /// <param name="children">Новая категория</param>
        public void Add(Category children)
        {
            // проверка на конфилкт имен категорий. не допускаем наличии категорий с одинаковым именем
            if (Childrens.Where(c => c.Name.Equals(children.Name.Trim(), StringComparison.CurrentCultureIgnoreCase))
                .Any()) throw new Exception(Name);

            // создаю slug для новой категории из ее имени
            string slug = SlugGenerator.ToUrlSlug(children.Name);
            children.Slug = slug;

            Childrens.Add(children);
        }

        public void Update(string name)
        {

            // Copy-Paste!!!
            // проверка на конфилкт имен категорий. не допускаем наличии категорий с одинаковым именем
            if (Childrens.Where(c => c.Name.Equals(name.Trim(), StringComparison.CurrentCultureIgnoreCase))
                .Any()) throw new Exception("Имя с заданным именем существует");

            this.Name = name;

            this.Slug = SlugGenerator.ToUrlSlug(name);
        }
        #endregion

        #region CRUD v2

        #endregion

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
