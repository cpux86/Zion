using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Features.Catalog.Queries.GetMenu
{
    public class GetMenuQuery : IRequest<List<MenuViewModele>>
    {
    }
}
