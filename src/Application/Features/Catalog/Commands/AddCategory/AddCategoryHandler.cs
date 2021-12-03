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

namespace Application.Features.Catalog.Commands.AddCategory
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
            // создаем новую катергорию
            Category subCategory = new Category(request.Name);
            if (request.ParentId == 0)
            {
                var isset = _catalogContext.Categories
                    .Where(p => p.Parent == null && p.Name == request.Name)
                    .FirstOrDefault();
                
                _catalogContext.Categories.Add(subCategory);

                await _catalogContext.SaveChangesAsync(cancellationToken);
                return subCategory.Id;
            }

            // получаем категорию в которую необходимо встваить подкатегорию
            Category parent = _catalogContext.Categories
                // подгружаем ее дочернии категории
                .Include(c => c.Categories)
                .Where(c => c.Id == request.ParentId)
                .FirstOrDefault();
            if (parent == null) return subCategory.Id;

            parent.Add(subCategory);


            await _catalogContext.SaveChangesAsync(cancellationToken);
            return subCategory.Id;
        }
    }
}
