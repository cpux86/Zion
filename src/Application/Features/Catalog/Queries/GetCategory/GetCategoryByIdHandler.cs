using Application.Common.Exceptions;
using Application.Interfaces;
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

namespace Application.Features.Catalog.Queries.GetCategory
{
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, CategoryViewModele>
    {
        private readonly ICatalogContext _catalogContext;
        private readonly IMapper _mapper;

        public GetCategoryByIdHandler(ICatalogContext catalogContext, IMapper mapper)
        {
            _catalogContext = catalogContext;
            _mapper = mapper;
        }

        public async Task<CategoryViewModele> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            Category category = await _catalogContext.Categories.FirstOrDefaultAsync(e => e.Id == request.Id);
            if (category == null) throw new NotFoundException("не найдена");
            return _mapper.Map<CategoryViewModele>(category);
        }
    }
}
