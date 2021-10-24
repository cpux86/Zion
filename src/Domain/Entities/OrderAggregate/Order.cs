using Domain.Common;
using Domain.Entities.ProductAggregate;
using System;
using System.Collections.Generic;

namespace Domain.Entities.OrderAggregate
{
    public class Order : BaseDeletableEntity
    {
        private Order()
        {
            //Id = Guid.NewGuid();
        }
        public Order(string userID)
        {
            // назначаем владельца сущьности
            CreatedBy = Guid.Parse(userID);
            // устанавливаем дату создания заказа, дата остается не изменна, не зависимо от статуса заказа
            CreatedOn = DateTimeOffset.UtcNow;
            ModifiedOn = DateTimeOffset.UtcNow;

        }
        private readonly Guid _userID;
        public Order(string title, string comments)
        {
            Title = title;
            Comments = comments;
        }

        public Guid Id { get; private set; }
        /// <summary>
        /// Заголовок, к примеру "Микросхема ШИМ-контроллера"
        /// </summary>
        public  string Title { get; set; }
        /// <summary>
        /// Комментарии, к промеру "Шим-контроллер с частоного преобразователя Siemens"
        /// </summary>
        public string Comments { get; set; }
        /// <summary>
        /// URL-адреса изображений искомых товаров
        /// </summary>
        public string ImageSource { get; set; } 
        /// <summary>
        /// товары предложенные продовцамаи, подходящие по описанию.
        /// </summary>
        public List<Product> Products { get; set; }
        
    }
}
