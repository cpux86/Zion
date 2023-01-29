using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Features.Catalog.Queries.GetCategory
{
    public class GetCategoryByIdQuery : IRequest<CategoryViewModel>
    {
        public long Id { get; set; }
    }
}
