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
            CreateMap<Product, ProductResponse>()
                .ForCtorParam(
                    nameof(ProductResponse.MainCategoryName),
                    opt => opt.MapFrom(src => src.MainCategory!.Name))
                .ForCtorParam(
                    nameof(ProductResponse.SubCategoryName),
                    opt => opt.MapFrom(src => src.SubCategory!.Name))
                .ForCtorParam(
                    nameof(ProductResponse.PackagingTypeName),
                    opt => opt.MapFrom(src => src.PackagingType!.Name));

            CreateMap<StockAdjustmentItem, StockAdjustmentItemResponse>()
                .ForCtorParam(
                    nameof(StockAdjustmentItemResponse.Product),
                    opt => opt.MapFrom(src => src.Product));

            CreateMap<StockAdjustment, StockAdjustmentResponse>()
                .ForCtorParam(
                    nameof(StockAdjustmentResponse.ResponsibleName),
                    opt => opt.MapFrom(src => src.Responsible.Name))
                .ForCtorParam(
                    nameof(StockAdjustmentResponse.AccountUserName),
                    opt => opt.MapFrom(src => src.Account.UserName))
                .ForCtorParam(
                    nameof(StockAdjustmentResponse.Items),
                    opt => opt.MapFrom(src => src.Items));
        }
    }
}
