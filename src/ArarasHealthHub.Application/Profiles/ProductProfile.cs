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
            CreateMap<Product, DropdownItemResponse>();

            CreateMap<Product, ProductResponse>()
                .ForMember(dest => dest.MainCategoryName,
                    opt => opt.MapFrom(src => src.MainCategory!.Name))
                .ForMember(dest => dest.SubCategoryName,
                    opt => opt.MapFrom(src => src.SubCategory!.Name))
                .ForMember(dest => dest.PackagingTypeName,
                    opt => opt.MapFrom(src => src.PackagingType!.Name));

            CreateMap<Product, ProductListItemResponse>()
                .ForMember(dest => dest.MainCategoryName,
                    opt => opt.MapFrom(src => src.MainCategory!.Name))
                .ForMember(dest => dest.SubCategoryName,
                    opt => opt.MapFrom(src => src.SubCategory!.Name))
                .ForMember(dest => dest.PackagingTypeName,
                    opt => opt.MapFrom(src => src.PackagingType!.Name));
        }
    }
}
