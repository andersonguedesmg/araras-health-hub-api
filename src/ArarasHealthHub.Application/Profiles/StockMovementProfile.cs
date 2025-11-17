using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.StockMovements.Dtos;
using ArarasHealthHub.Domain.Entities;
using AutoMapper;

namespace ArarasHealthHub.Application.Profiles
{
    public class StockMovementProfile : Profile
    {
        public StockMovementProfile()
        {
            CreateMap<StockMovement, StockMovementDto>()
                .ForMember(dest => dest.ProductName,
                           opt => opt.MapFrom(src => src.StockLot.Stock.Product.Name))

                .ForMember(dest => dest.ProductId,
                           opt => opt.MapFrom(src => src.StockLot.Stock.ProductId))

                .ForMember(dest => dest.Batch,
                           opt => opt.MapFrom(src => src.StockLot.Batch))

                .ForMember(dest => dest.Brand,
                           opt => opt.MapFrom(src => src.StockLot.Brand))

                .ForMember(dest => dest.ExpiryDate,
                           opt => opt.MapFrom(src => src.StockLot.ExpiryDate))

                .ForMember(dest => dest.ResponsibleName,
                           opt => opt.MapFrom(src => src.Responsible.Name));
        }
    }
}
