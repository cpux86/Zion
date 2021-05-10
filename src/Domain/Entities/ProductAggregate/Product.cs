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
        public string Title { get; set; }
        /// <summary>
        /// Описание товара
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Цена товара
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Категории в которые входит продукт
        /// </summary>
        public IEnumerable<Category> Categories { get; private set; }
        /// <summary>
        /// Характеристики товара
        /// </summary>
        public IReadOnlyCollection<Properties> Properties => _properties.AsReadOnly();

        private readonly List<Properties> _properties = new List<Properties>();
        private Product()
        {
        }
        public Product(string name)
        {
            // валидация параметров
            Title = name;

        }
        /// <summary>
        /// прикрепите продукт к категориям 
        /// </summary>
        public void AttachProductToCategories(IEnumerable<Category> categories)
        {
            // исключаем возможность добавления повторяющихся категорий
            //IEnumerable<Category> newCategoryList = categories.Distinct<Category>();
            Categories = categories.Distinct<Category>();
            
        }

        public void UpdateDetails(string name, string description, decimal price)
        {
            // валидация параметров
            // ........
            Guard.Against.NullOrEmpty(name, nameof(name));
            Guard.Against.NullOrEmpty(description, nameof(description));
            Title = name;
            Description = description;
            Price = price;
        }


        public void AddProductProperty()
        {
            _properties.Add(new Properties());
        }

        

        
    }
}
