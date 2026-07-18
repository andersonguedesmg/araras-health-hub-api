using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.StockMovements.Responses;
using ArarasHealthHub.Domain.Entities;

using AutoMapper;

namespace ArarasHealthHub.Application.Profiles
{
    public class StockMovementProfile : Profile
    {
        public StockMovementProfile()
        {
            CreateMap<StockMovement, StockMovementResponse>()
                .ForCtorParam(
                    nameof(StockMovementResponse.ProductId),
                    opt => opt.MapFrom(src => src.StockLot.Stock.ProductId))
                .ForCtorParam(
                    nameof(StockMovementResponse.ProductName),
                    opt => opt.MapFrom(src => src.StockLot.Stock.Product.Name))
                .ForCtorParam(
                    nameof(StockMovementResponse.ResponsibleName),
                    opt => opt.MapFrom(src => src.Responsible.Name));
        }
    }
}
