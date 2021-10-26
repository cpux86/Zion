using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.OrderAggregate
{
    /// <summary>
    /// 
    /// </summary>
    public enum OrderStatus
    {
        Active,    
        Disabled,
        Locked,
        Deleted
    }
}
