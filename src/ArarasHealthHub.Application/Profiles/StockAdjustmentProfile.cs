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
            CreateMap<StockAdjustment, StockAdjustmentDto>().ReverseMap();
        }
    }
}
