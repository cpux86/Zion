using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IAuditInfo
    {
        /// <summary>
        /// Дата создания сущности
        /// </summary>
        DateTime CreatedOn { get; set; }
        /// <summary>
        /// Владелец сущности(ID юзера)
        /// </summary>
        string CreatedBy { get; set; }
        /// <summary>
        /// Дата изменения сущности
        /// </summary>
        DateTime? ModifiedOn { get; set; }
        /// <summary>
        /// Дата публикации заказа
        /// </summary>
        DateTime? PublicationDate { get; set; }
        /// <summary>
        /// опубликован ли заказ
        /// </summary>
        public bool IsActive { get; set; }
    }
}
