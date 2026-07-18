using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Products.Responses;
using ArarasHealthHub.Application.Features.Stocks.Responses;
using ArarasHealthHub.Domain.Entities;

using AutoMapper;

namespace ArarasHealthHub.Application.Profiles
{
    public class StockAdjustmentProfile : Profile
    {
        public StockAdjustmentProfile()
        {
            CreateMap<Product, ProductResponse>();

            CreateMap<StockAdjustmentItem, StockAdjustmentItemResponse>();

            CreateMap<StockAdjustment, StockAdjustmentResponse>()
                .ForCtorParam(
                    nameof(StockAdjustmentResponse.ResponsibleName),
                    opt => opt.MapFrom(src => src.Responsible.Name))
                .ForCtorParam(
                    nameof(StockAdjustmentResponse.AccountUserName),
                    opt => opt.MapFrom(src => src.Account.UserName));
        }
    }
}
