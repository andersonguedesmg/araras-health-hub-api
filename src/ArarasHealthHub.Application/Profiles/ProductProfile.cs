using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Products.Responses;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Responses;

using AutoMapper;

namespace ArarasHealthHub.Application.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, DropdownItemResponse>()
                .ForCtorParam("Label", opt => opt.MapFrom(src => src.Name));

            CreateMap<Product, ProductResponse>();

            CreateMap<Product, ProductListItemResponse>();
        }
    }
}
