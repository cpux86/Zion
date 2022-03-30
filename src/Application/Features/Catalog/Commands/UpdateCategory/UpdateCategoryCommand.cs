using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serivce.Features.Catalog.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest
    {
        public long Id { get; set; }
        public string Name { get; set; }
        //public string Description { get; set; }
    }
}
