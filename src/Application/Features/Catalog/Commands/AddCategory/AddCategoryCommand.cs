﻿using Domain.Entities.Catalog;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Features.Catalog.Commands.AddCategory
{
    public class AddCategoryCommand : IRequest<long>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// Назначение. Родительская категория
        /// </summary>
        public long ParentId { get; set; }
    }
}
