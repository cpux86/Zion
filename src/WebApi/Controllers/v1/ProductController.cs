
using Application.Features.Catalog.Queries.GetCategoriesList;
using Application.Wrappers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ProductController : BaseApiController
    {
        //[Route("{id}/[action]")]
        [HttpGet]
        public async Task<MenuViewModele> Create()
        {
            var query = new GetCategoriesListQuery();
            return await Mediator.Send(query);
            //return new Response<int>("готово");
        }

    }
}
