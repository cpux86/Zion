
using Serivce.Features.Catalog.Commands.AddCategory;
using Serivce.Features.Catalog.Commands.DeleteCategory;
using Serivce.Features.Catalog.Commands.UpdateCategory;
using Serivce.Features.Catalog.Queries.GetCategory;
using Serivce.Features.Catalog.Queries.GetMenu;
using Serivce.Wrappers;
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

        // Получить категорию по id
        //[Route("{id}")]
        [HttpGet("{id}", Name = "GetCategoryById")]
        public async Task<CategoryViewModele> GetCategoryById(long id)
        {
            var query = new GetCategoryByIdQuery { Id = id };
            var result = await Mediator.Send(query);
            return result;
        }


        // Вставить новую категорию
        [Route("{id?}")]
        [HttpPost]
        public async Task<ActionResult<Response<string>>> Create([FromForm] CreateCategoryDto dto, long id)
        {
            var command = new AddCategoryCommand { Name = dto.Name, ParentId = id };
            var status = await Mediator.Send(command);
            if (status == 0) return new Response<string>();
            var vm = new Response<long>(status);
            return CreatedAtRoute("GetCategoryById", new { id = status }, vm);
            //return Ok(vm);
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
        // Обновить категорию
        [Route("{id}")]
        [HttpPut]
        public async Task<ActionResult> Update([FromForm]UpdateCategoryCommand command, long id)
        {
            command.Id = id;
            await Mediator.Send(command);
            var vm = new Response<string>(null, "succeeded");
            return Ok(vm);
        }


    }
}
