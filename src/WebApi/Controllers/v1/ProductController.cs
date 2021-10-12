
using Application.Wrappers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ProductController : BaseApiController
    {
        //[Route("{id}/[action]")]
        //[HttpPost]
        //public async Task<Response<int>> Create(SaveProductCommand command)
        //{
        //    return await Mediator.Send(command);
        //    //return new Response<int>("готово");
        //}

    }
}
