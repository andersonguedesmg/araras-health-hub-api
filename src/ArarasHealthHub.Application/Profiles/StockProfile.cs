using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Products.Dtos;
using ArarasHealthHub.Application.Features.Stocks.Dtos;
using ArarasHealthHub.Domain.Entities;
using AutoMapper;

namespace ArarasHealthHub.Application.Profiles
{
    public class StockProfile : Profile
    {
        public StockProfile()
        {
            CreateMap<Product, ProductDto>();

            CreateMap<Stock, StockDto>();

            CreateMap<Stock, StockGeneralOverviewDto>();

            CreateMap<Stock, StockMinQuantityDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.ProductMainCategory, opt => opt.MapFrom(src => src.Product.MainCategory))
                .ForMember(dest => dest.ProductSubCategory, opt => opt.MapFrom(src => src.Product.SubCategory))
                .ForMember(dest => dest.ProductPresentationForm, opt => opt.MapFrom(src => src.Product.PresentationForm))
                .ForMember(dest => dest.ProductIsActive, opt => opt.MapFrom(src => src.Product.IsActive));
        }
    }
}
