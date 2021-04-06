using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using Ardalis.GuardClauses;
using System.Linq;

namespace Domain.Entities.ProductAggregate
{
    public class Product : AggregateRoot<int>
    {
        /// <summary>
        /// Название товара
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Описание товара
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Цена товара
        /// </summary>
        public decimal Price { get; private set; }
        /// <summary>
        /// Категории в которые входит продукт
        /// </summary>
        public IReadOnlyCollection<Category> ProductCategories => _categories.AsReadOnly();
        /// <summary>
        /// Характеристики товара
        /// </summary>
        public IReadOnlyCollection<Properties> Properties => _properties.AsReadOnly();

        private readonly List<Category> _categories = new List<Category>();
        private readonly List<Properties> _properties = new List<Properties>();
        private Product()
        {
        }
        public Product(string name, List<Category> category)
        {
            // валидация параметров
            // ........
            Guard.Against.NullOrEmpty(name, nameof(name));
            Name = name;
            _categories = category;

        }
        /// <summary>
        /// Обнавить список категории в которые входит продукт
        /// </summary>
        public void UpdateCategoriesTheCurrentProduct(HashSet<Category> categories)
        {
            // исключаем возможность добавления повторяющихся категорий
            //IEnumerable<Category> newCategoryList = categories.Distinct<Category>();
            
            IEnumerable<Category> c = categories;
        }
        public void UpdateDetails(string name, string description, decimal price)
        {
            // валидация параметров
            // ........
            Guard.Against.NullOrEmpty(name, nameof(name));
            Guard.Against.NullOrEmpty(description, nameof(description));
            Name = name;
            Description = description;
            Price = price;
        }


        public void AddProductProperty()
        {
            _properties.Add(new Properties());
        }

        

        
    }
}
