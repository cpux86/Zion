using Domain.Entities.ProductAggregate;
using MediatR;
using Serivce.Common.Exceptions;
using Serivce.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Catalog.ProductFeatures.Commandes.DeleteProductById
{
    public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand>
    {
        private readonly ICatalogContext _catalogContext;

        public DeleteProductByIdCommandHandler(ICatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }

        public async Task<Unit> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = new Product() { Id = request.Id };
                _catalogContext.Products.Remove(product);
                await _catalogContext.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
            catch (Exception)
            {

                throw new BadRequestException("Bad Request");
            }
            
        }
    }
}
