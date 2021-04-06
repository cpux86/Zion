﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Common
{
    public abstract class BaseEntity<TKey> : IHasKey<TKey>
    {
        [Key]
        public TKey Id { get; set; }

    }
}
