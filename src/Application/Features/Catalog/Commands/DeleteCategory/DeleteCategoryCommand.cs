﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Catalog.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest
    {
        public long Id { get; set; }
    }
}
