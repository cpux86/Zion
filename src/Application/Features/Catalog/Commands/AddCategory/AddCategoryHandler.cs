using Service.Common.Exceptions;
using Domain.Entities.Catalog;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Service.Interfaces;

namespace Service.Features.Catalog.Commands.AddCategory
{
    public class AddCategoryHandler : IRequestHandler<AddCategoryCommand, long>
    {
        private readonly ICatalogContext _catalogContext;

        public AddCategoryHandler(ICatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }

        public async Task<long> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            // создаем новую категорию
            Category subCategory = new Category(request.Name);
            if (request.ParentId == 0)
            {
                var isset = _catalogContext.Categories
                    .Where(p => p.Parent == null && p.Name == request.Name)
                    .Any();

                if (isset) throw new Exception("Конфликт имен");
                _catalogContext.Categories.Add(subCategory);
                

                await _catalogContext.SaveChangesAsync(cancellationToken);
                return subCategory.Id;
            }

            // получаем категорию в которую необходимо вставить подкатегорию
            var parent = _catalogContext.Categories
                // подгружаем ее дочерние категории
                .Include(c => c.Categories)
                .Where(c => c.Id == request.ParentId)
                ?.FirstOrDefault();
            if (parent == null) return subCategory.Id;

            parent.Add(subCategory);

            
            await _catalogContext.SaveChangesAsync(cancellationToken);
            return subCategory.Id;
        }
    }
}
