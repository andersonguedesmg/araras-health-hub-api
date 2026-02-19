using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Products.Commands.CreateProduct;
using ArarasHealthHub.Application.Features.Products.Commands.UpdateProduct;
using ArarasHealthHub.Application.Features.Products.Dtos;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Dtos;

using AutoMapper;

namespace ArarasHealthHub.Application.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, DropdownItemDto>();

            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.MainCategoryName, opt => opt.MapFrom(src => src.MainCategory!.Name))
                .ForMember(dest => dest.SubCategoryName, opt => opt.MapFrom(src => src.SubCategory!.Name))
                .ForMember(dest => dest.PresentationFormName, opt => opt.MapFrom(src => src.PresentationForm!.Name));

            CreateMap<CreateProductCommand, Product>();
            CreateMap<UpdateProductCommand, Product>();
        }
    }
}
