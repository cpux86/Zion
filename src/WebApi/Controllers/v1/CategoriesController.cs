
using Application.Features.Catalog.Commands.AddCategory;
using Application.Features.Catalog.Commands.DeleteCategory;
using Application.Features.Catalog.Queries.GetCategoriesList;
using Application.Wrappers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Modeles;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CategoriesController : BaseApiController
    {
        private readonly IMapper _mapper;

        public CategoriesController(IMapper mapper)
        {
            _mapper = mapper;
        }

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
        //[Route("{id}")]
        [HttpPost]
        public async Task<ActionResult<Response<string>>> Create([FromHeader] CreateCategoryDto dto)
        {
            var command = new AddCategoryCommand { Name = "555555", ParentId = 1 };
            var status = await Mediator.Send(command);
            if (status == 0) return new Response<string>();
            var vm = new Response<long>(status);
            return Ok(vm);
        }
        // Удалить категорию
        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult<Response<string>>> Delete(long id)
        {
            var command = new DeleteCategoryCommand { Id = id };
            var status = await Mediator.Send(command);
            if (!status) return new Response<string>();
            var vm = new Response<bool>(status);
            return Ok(vm);
        }

    }
}
