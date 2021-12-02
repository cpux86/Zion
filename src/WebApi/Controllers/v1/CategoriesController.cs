
using Application.Features.Catalog.Commands.AddCategory;
using Application.Features.Catalog.Commands.DeleteCategory;
using Application.Features.Catalog.Queries.GetMenu;
using Application.Wrappers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        public async Task<ActionResult<Response<MenuVm>>> GetAllMenu()
        {
            var query = new GetMenuQuery();
            var menu =  await Mediator.Send(query);
            var vm = new Response<List<MenuViewModele>>(menu);
            return Ok(vm);
        }
        // Вставить новую категорию
        [Route("{id?}")]
        [HttpPost]
        public async Task<ActionResult<Response<string>>> Create([FromHeader] CreateCategoryDto dto, long id = 1)
        {
            var command = new AddCategoryCommand { Name = dto.Name, ParentId = id };
            var status = await Mediator.Send(command);
            if (status == 0) return new Response<string>();
            var vm = new Response<long>(status);
            return Ok(vm);
        }
        // Удалить категорию
        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> Delete([FromQuery] DeleteCategoryCommand command, long id)
        {
            command.Id = id;
            await Mediator.Send(command);
            var vm = new Response<string>(null,"succeeded");
            return Ok(vm);
        }

    }
}
