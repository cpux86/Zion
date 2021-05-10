using Application.Features.ProductFeatures.Commands;
using AutoMapper;
using Domain.Entities.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<SaveProductCommand, Product>();
        }
    }
}
