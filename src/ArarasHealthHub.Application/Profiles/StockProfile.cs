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

            CreateMap<Stock, StockOverviewDto>();

            CreateMap<Stock, StockMinQuantityDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.ProductCode, opt => opt.MapFrom(src => src.Product.Description))
                .ForMember(dest => dest.ProductIsActive, opt => opt.MapFrom(src => src.Product.IsActive));
        }
    }
}
