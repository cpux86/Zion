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
            var subCategory = new Category(request.Name);

            // получаем категорию в которую необходимо встваить подкатегорию
            Category parent = _catalogContext.Categories
                // подгружаем ее дочернии категории
                .Include(c => c.Childrens)
                .Where(c => c.Id == request.ParentId)
                .FirstOrDefault();

            //parent.Add(subCategory);
            try
            {
                //Category children = parent.Add(request.Name);
                parent.Add(subCategory);
            }
            catch (Exception e)
            {

                //subCategory.Id = 0;
            }

            await _catalogContext.SaveChangesAsync(cancellationToken);
            return subCategory.Id;
        }
    }
}
