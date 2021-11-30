using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Entities.Catalog;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Catalog.Commands.DeleteCategory
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly ICatalogContext _catalogContext;

        public DeleteCategoryHandler(ICatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = await _catalogContext.Categories.FindAsync(request.Id);
            // если запрошенной категори не существует, то выбрасываем исключение
            if (category == null) throw new BadRequestException();
            
            try
            {
                _catalogContext.Categories.Remove(category);
                await _catalogContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception e)
            {
                throw new Exception("unidentified");
            }
            return Unit.Value;
                      
        }

    }
}
