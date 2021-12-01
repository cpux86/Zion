﻿
using Application.Features.Catalog.Queries.GetMenu;
using AutoMapper;
using Domain.Entities.Catalog;
using Domain.Entities.ProductAggregate;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            AllowNullCollections = true;
            CreateMap<Category, MenuViewModele>()
                .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Categories))
                .ForMember(dest => dest.Url, opt => opt.MapFrom(src =>src.Parent.Slug+"/"+ src.Slug+"-"+src.Id))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl));

        }
    }
}
