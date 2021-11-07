using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Catalog.Commands.AddCategory
{
    public class AddCategoryCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// Назначение. Родительская категория
        /// </summary>
        public string CategoryParent { get; set; }
    }
}
