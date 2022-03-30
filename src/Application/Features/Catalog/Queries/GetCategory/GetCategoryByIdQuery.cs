using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serivce.Features.Catalog.Queries.GetCategory
{
    public class GetCategoryByIdQuery : IRequest<CategoryViewModele>
    {
        public long Id { get; set; }
    }
}
