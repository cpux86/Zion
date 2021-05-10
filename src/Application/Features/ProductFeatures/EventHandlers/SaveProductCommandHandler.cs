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
using AutoMapper;
using Domain.Interfaces.Repositories;

namespace Application.Features.ProductFeatures.EventHandlers
{
    public class SaveProductCommandHandler : IRequestHandler<SaveProductCommand, Response<int>>
    {
        private readonly IProductRepositoryAsync _repo;
        private readonly IMapper _mapper;
        public SaveProductCommandHandler(IProductRepositoryAsync productRepository , IMapper mapper)
        {
           _repo = productRepository;
            _mapper = mapper;

        }

        public async Task<Response<int>> Handle(SaveProductCommand command, CancellationToken cancellationToken)
        {

            Product product = _mapper.Map<Product>(command);
            
            await _repo.UpdateAsync(product);

            return await Task.FromResult(new Response<int>("готово"));
        }
    }
}
