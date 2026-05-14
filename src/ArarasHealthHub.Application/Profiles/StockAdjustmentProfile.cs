using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Stocks.Commands.CreateStockAdjustment;
using ArarasHealthHub.Application.Features.Stocks.Dtos;
using ArarasHealthHub.Domain.Entities;
using AutoMapper;

namespace ArarasHealthHub.Application.Profiles
{
    public class StockAdjustmentProfile : Profile
    {
        public StockAdjustmentProfile()
        {
            CreateMap<StockAdjustmentItem, StockAdjustmentItemDto>();

            CreateMap<StockAdjustment, StockAdjustmentDto>()
                .ForMember(dest => dest.Type,
                           opt => opt.MapFrom(src => src.Type.ToString()))
                .ForMember(dest => dest.ResponsibleName,
                           opt => opt.MapFrom(src => src.Responsible != null ? src.Responsible.Name : "N/A"))
                .ForMember(dest => dest.AccountUserName,
                           opt => opt.MapFrom(src => src.Account != null ? src.Account.UserName : "N/A"))
                .ForMember(dest => dest.AdjustmentItems,
                           opt => opt.MapFrom(src => src.Items));

            CreateMap<CreateStockAdjustmentItemCommand, StockAdjustmentItem>()
                .ForMember(dest => dest.TotalValue, opt => opt.Ignore());

            CreateMap<CreateStockAdjustmentCommand, StockAdjustment>()
                .ForMember(dest => dest.Items,
                           opt => opt.MapFrom(src => src.AdjustmentItems))
                .ForMember(dest => dest.Responsible, opt => opt.Ignore())
                .ForMember(dest => dest.Account, opt => opt.Ignore());
        }
    }
}
