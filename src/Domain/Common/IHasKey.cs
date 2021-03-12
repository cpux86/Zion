using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Common
{
    public interface IHasKey<T>
    {
        [Key]
        T Id { get; set; }
    }
}
