using Application.Features.ProductFeatures.Commands;
using Application.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ProductController : BaseApiController
    {
        //[Route("{id}/[action]")]
        [HttpPost]
        public async Task<Response<int>> Create(SaveProductCommand command)
        {
            return await Mediator.Send(command);
            //return new Response<int>("готово");
        }

    }
}
