using Application.Features.ProductFeatures.Commands;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.EventHandlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Response<int>>
    {
        public CreateProductCommandHandler()
        {
        }

        public Task<Response<int>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new Response<int>("готово")) ;
        }

        //public Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        //{
        //    return Task.FromResult(Unit.Value);
        //}
    }
}
