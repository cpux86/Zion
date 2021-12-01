using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Entities.Catalog;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
            Category category = await _catalogContext.Categories
                .Where(c => c.Id == request.Id)
                .Include(ch => ch.Categories)
                .FirstOrDefaultAsync();
            if (category == null) throw new NotFoundException("не найдена");

            bool isEmpty = category.Categories.Any();
            if (request.Items != "all" && isEmpty) throw new Exception("Категория не пуста");
            //category.Categories.Count
            //await _catalogContext.Categories.ToListAsync();
            //Category category = await _catalogContext.Categories
            //    .Where(c => c.Id == request.Id)
            //    .Include(ch => ch.Categories)
            //    .FirstOrDefaultAsync();
            //var list = category.Categories.ToArray();
            // если запрошенной категори не существует, то выбрасываем исключение
            
            
            try
            {
                _catalogContext.Categories.Remove(category);
                await _catalogContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception)
            {
                throw new Exception("unidentified");
            }
            return Unit.Value;
                      
        }

    }
}
