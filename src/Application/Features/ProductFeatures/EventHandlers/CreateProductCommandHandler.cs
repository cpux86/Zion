using Application.Features.ProductFeatures.Commands;
using Application.Wrappers;
using Domain.Entities;
using Domain.Entities.ProductAggregate;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Application.Features.ProductFeatures.EventHandlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Response<int>>
    {
        private readonly IGenericRepositoryAsync<Category, int> _repo;
        public CreateProductCommandHandler(IGenericRepositoryAsync<Category, int> genericRepository)
        {
            _repo = genericRepository;
        }

        public async Task<Response<int>> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            // запрашиваем в хранилище категорий, категорию в которую необходимо добавить продукт
            List<Category> categories = new List<Category>();
            categories.Distinct<Category>();
            foreach (var item in command.Categories)
            {
                
                categories.Add(await _repo.GetByIdAsync(item));
            }
            //Category category = await _repo.GetByIdAsync(command.Categories);
            // создаем продукт
            Product product = new Product(command.Title, categories);
            
            product.Description = command.Description;
            

            return await Task.FromResult(new Response<int>(1,"готово"));
        }

        //public Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        //{
        //    return Task.FromResult(Unit.Value);
        //}
    }
}
