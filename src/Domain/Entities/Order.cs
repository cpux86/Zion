using Domain.Common;
using Domain.Entities.ProductAggregate;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Order : BaseEntity
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Заголовок, к примеру "Микросхема ШИМ-контроллера"
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Комментарии, к промеру "Шим-контроллер с частоного преобразователя Siemens"
        /// </summary>
        public string Comments { get; set; }
        /// <summary>
        /// URL-адреса изображений искомых товаров
        /// </summary>
        public IEnumerable<string> ProductImagesURLs { get; set; } = new HashSet<string>();
        /// <summary>
        /// товары предложенные продовцамаи, подходящие по описанию.
        /// </summary>
        public IEnumerable<Product> Products { get; set; } = new HashSet<Product>();
    }
}
