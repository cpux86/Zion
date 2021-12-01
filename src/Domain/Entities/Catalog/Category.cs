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
        // Максимальная глубина вложенности меню
        const int _maxDeph = 5;
        private Category()
        {
            // Требуется для EF
        }

        public Category(string name)
        {
            Name = name;
            // создаю slug для новой категории из ее имени
            Slug = SlugGenerator.ToUrlSlug(name);
        }

        public long Id { get; set; }
        public string Name { get; private set; }
        /// <summary>
        /// Путь к файлу изображения категории
        /// </summary>
        public string ImageUrl { get; private set; }
        /// <summary>
        /// последняя секция URL
        /// </summary>
        public string Slug { get; private set; }
        

        public int Lavel { get; private set; }
        /// <summary>
        /// Родительская категория
        /// </summary>
        public virtual Category Parent { get; private set; }

        // дочерние категории
        public virtual List<Category> Categories { get; private set; }
        // Заказы. Запрос на приобретение товара, содержащий описание товара
        public virtual List<Order> Orders { get; private set; }
        // товары которые уже имеются в категории
        public virtual List<Product> Products { get; private set; }

        #region CRUD v1
        /// <summary>
        /// Добавить подкатегорию
        /// </summary>
        /// <param name="children">Новая категория</param>
        public void Add(Category children)
        {
            // проверка на конфилкт имен категорий. не допускаем наличии категорий с одинаковым именем
            if (Categories.Where(c => c.Name.Equals(children.Name.Trim(), StringComparison.CurrentCultureIgnoreCase))
                .Any()) throw new Exception("Конфликт имен");
            
            // вычисляю значение глубины для  новой категории
            int level = Lavel + 1;
            // проверяю, не достигла новая категория максимальной глубины
            if (level > _maxDeph) throw new Exception("не допустимая глубина вложения");
            // устанавливаю значение глубины для новой категории
            children.Lavel = level;

            Categories.Add(children);
        }

        public void Update(string name)
        {
            this.Name = name;

            this.Slug = SlugGenerator.ToUrlSlug(name);
        }
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
