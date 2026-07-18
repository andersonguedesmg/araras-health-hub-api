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
    public class StockProfile : Profile
    {
        public StockProfile()
        {
            CreateMap<Product, ProductResponse>()
                .ForCtorParam(
                    nameof(ProductResponse.UpdatedOn),
                    opt => opt.MapFrom(src => src.UpdatedOn ?? src.CreatedOn));

            CreateMap<Stock, StockResponse>()
                .ForCtorParam(
                    nameof(StockResponse.AverageCost),
                    opt => opt.MapFrom(src => src.StockCost != null ? src.StockCost.AverageUnitCost : 0));
        }
    }
}
