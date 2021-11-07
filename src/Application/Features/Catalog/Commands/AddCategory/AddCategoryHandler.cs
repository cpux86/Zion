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
    public class AddCategoryHandler : IRequestHandler<AddCategoryCommand, Guid>
    {
        private readonly ICatalogContext _catalogContext;

        public AddCategoryHandler(ICatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }

        public async Task<Guid> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            // создаем новую катергорию
            var newCategory = new Category(request.Name);

            // получаем категорию в которую необходимо встваить подкатегорию
            Category parent = _catalogContext.Categories.Include(c => c.Childrens)
                .Where(c => c.Id == Guid.Parse(request.CategoryParent))
                .FirstOrDefault();

            parent.AddCategory(newCategory);

            //_catalogContext.Categories.Add(newCategory);

            await _catalogContext.SaveChangesAsync(cancellationToken);
            return newCategory.Id;
        }
    }
}
