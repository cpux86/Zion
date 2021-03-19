using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using Ardalis.GuardClauses;

namespace Domain.Entities.ProductAggregate
{
    public class Product : AggregateRoot<Guid>
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
        public Category Category { get; private set; }
        /// <summary>
        /// Характеристики товара
        /// </summary>
        public IReadOnlyCollection<Properties> Properties => _properties.AsReadOnly();

        private readonly List<Properties> _properties = new List<Properties>();
        private Product()
        {
        }
        public Product(string name, Category category)
        {
            // валидация параметров
            // ........
            Guard.Against.NullOrEmpty(name, nameof(name));
            Name = name;
            Category = category;

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
