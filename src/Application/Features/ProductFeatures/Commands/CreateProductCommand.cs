using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.ProductFeatures.Commands
{
    public class CreateProductCommand : IRequest<Response<int>>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string Images { get; set; }
        public decimal Price { get; set; }
        
    }
}
