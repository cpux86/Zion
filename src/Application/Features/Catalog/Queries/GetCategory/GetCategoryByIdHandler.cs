using AutoMapper;
using Domain.Entities.Catalog;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Service.Common.Exceptions;
using Service.Interfaces;

namespace Service.Features.Catalog.Queries.GetCategory
{
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, CategoryViewModel>
    {
        private readonly ICatalogContext _catalogContext;
        private readonly IMapper _mapper;

        public GetCategoryByIdHandler(ICatalogContext catalogContext, IMapper mapper)
        {
            _catalogContext = catalogContext;
            _mapper = mapper;
        }

        public async Task<CategoryViewModel> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _catalogContext.Categories.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);
            if (category == null) throw new NotFoundException("не найдена");
            return _mapper.Map<CategoryViewModel>(category);
        }
    }
}
