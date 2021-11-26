
using Application.Features.Catalog.Commands.AddCategory;
using Application.Features.Catalog.Queries.GetCategoriesList;
using Application.Wrappers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CategoriesController : BaseApiController
    {
        //[Route("{id}/[action]")]
        // Получить все категории каталога
        [HttpGet]
        public async Task<ActionResult<Response<MenuViewModele>>> GetAllMenu()
        {
            var query = new GetCategoriesListQuery();
            var menu =  await Mediator.Send(query);
            var vm = new Response<MenuViewModele>(menu);
            return Ok(vm);
        }
        // Вставить новую категорию
        [Route("{id}")]
        [HttpPost]
        public async Task<ActionResult<Response<bool>>> Create([FromHeader] AddCategoryCommand command, [FromQuery] long id)
        {
            var i = id;
            //var query = new GetCategoriesListQuery();
            //var menu = await Mediator.Send(query);
            var vm =  new Response<bool>(true);
            return Ok(vm);
        }

    }
}
