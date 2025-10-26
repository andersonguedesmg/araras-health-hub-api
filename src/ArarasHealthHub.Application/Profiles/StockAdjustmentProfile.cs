using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Stocks.Dtos;
using ArarasHealthHub.Domain.Entities;
using AutoMapper;

namespace ArarasHealthHub.Application.Profiles
{
    public class StockAdjustmentProfile : Profile
    {
        public StockAdjustmentProfile()
        {
            CreateMap<StockAdjustmentItem, StockAdjustmentItemDto>()
                .ForMember(dest => dest.ProductName,
                           opt => opt.MapFrom(src => src.Product.Name));

            CreateMap<StockAdjustment, StockAdjustmentDto>()
                .ForMember(dest => dest.Type,
                           opt => opt.MapFrom(src => src.Type.ToString()))
                .ForMember(dest => dest.ResponsibleName,
                           opt => opt.MapFrom(src => src.Responsible != null ? src.Responsible.Name : "N/A"))
                .ForMember(dest => dest.AdjustmentItems,
                           opt => opt.MapFrom(src => src.AdjustmentItems));
        }
    }
}
