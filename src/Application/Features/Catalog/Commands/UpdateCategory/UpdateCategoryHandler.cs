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

namespace Application.Features.Catalog.Commands.UpdateCategory
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly ICatalogContext _catalogContext;

        public UpdateCategoryHandler(ICatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            // получаю категорию для обнавления
            Category category = _catalogContext.Categories
                .Where(c => c.Id == request.Id)
                //.Include(c => c.Childrens)
                .Include(p=>p.Parent)
                .FirstOrDefault();


            if (category == null) throw new Exception("Категория не найдена");
            category.Update(request.Name);
            await _catalogContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
