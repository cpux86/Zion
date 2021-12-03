﻿using Application.Interfaces;
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
            Category updateCategory = _catalogContext.Categories
                .Where(c => c.Id == request.Id)
                .Include(p=>p.Parent)
                .FirstOrDefault();
            if (updateCategory == null) throw new Exception("Category not found");
            // проверяю, будет ли конфиктовать переименованная категория с другими категориями
            bool exist = _catalogContext.Categories
                .Where(c => c.Parent == updateCategory.Parent && c.Id != request.Id)
                .Any(e => e.Name == request.Name);

            if (exist) throw new Exception("Конфликт имен");

            
            updateCategory.Update(request.Name);




            await _catalogContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
