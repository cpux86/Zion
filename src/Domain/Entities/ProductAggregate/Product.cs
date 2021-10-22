using Domain.Common;
using System;
using System.Collections.Generic;
//using Ardalis.GuardClauses;

namespace Domain.Entities.ProductAggregate
{
    public class Product
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Название товара
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Описание товара
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// URL-адреса изображений товара
        /// </summary>
        //public IEnumerable<string> ProductImagesURLs { get; set; } = new HashSet<string>();
        /// <summary>
        /// Цена товара
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Категория в которую входит продукт
        /// </summary>a
        public int CategoryProduct { get; set; }

        private Product()
        {
        }
        public Product(string name)
        {
            // валидация параметров
            Name = name;

        }

    }
}
