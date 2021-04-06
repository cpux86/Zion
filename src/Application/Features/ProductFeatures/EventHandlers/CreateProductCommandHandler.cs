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
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Response<int>>
    {
        private readonly IProductRepositoryAsync _repo;
        public CreateProductCommandHandler(IProductRepositoryAsync genericRepository , IMapper mapper)
        {
           _repo = genericRepository;
        }

        public async Task<Response<int>> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            
            

            return await Task.FromResult(new Response<int>(1,"готово"));
        }
    }
}
