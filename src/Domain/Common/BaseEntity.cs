using Domain.Contracts;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Common
{
    public abstract class BaseEntity : IAuditInfo
    {
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime? PublicationDate { get; set; }
        public bool IsActive { get; set; }
    }
}
