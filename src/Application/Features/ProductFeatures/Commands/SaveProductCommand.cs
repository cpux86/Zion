using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.ProductFeatures.Commands
{
    public class SaveProductCommand : IRequest<Response<int>>
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<int> Categories { get; set; }
        public string Images { get; set; }
        public decimal Price { get; set; }
        
    }
}
