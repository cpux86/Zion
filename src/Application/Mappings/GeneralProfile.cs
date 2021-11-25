
using Application.Features.Catalog.Queries.GetCategoriesList;
using AutoMapper;
using Domain.Entities.Catalog;
using Domain.Entities.ProductAggregate;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap <Category, MenuViewModele>();
        }
    }
}
