﻿using Serivce.Common.Exceptions;
using Serivce.Interfaces;
using Domain.Entities.Catalog;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Serivce.Features.Catalog.Commands.DeleteCategory
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
            // получаю категорию для удаления
            Category category = await _catalogContext.Categories
                .Where(c => c.Id == request.Id)
                .FirstOrDefaultAsync();
            // если запрошенной категори не существует, то выбрасываем исключение
            if (category == null) throw new NotFoundException("категория не найдена");
            // проверяю категорию на пустоту
            bool isNotEmpty = _catalogContext.Categories.Where(ch => ch.Parent.Id == request.Id).Any();
            // если удаляемая категория содержит вложенные категории (не пуста).
            // если request.Items = all, то согласно запросу разрешаем удалять категории с ее содержимым
            if (!request.Force && isNotEmpty) throw new Exception("Категория не пуста");

            
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
