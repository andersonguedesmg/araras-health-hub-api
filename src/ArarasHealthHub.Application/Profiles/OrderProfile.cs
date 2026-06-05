using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Orders.Responses;
using ArarasHealthHub.Domain.Entities;

using AutoMapper;

namespace ArarasHealthHub.Application.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderItem, OrderItemResponse>()
                .ForCtorParam(
                    "ProductId",
                    opt => opt.MapFrom(src => src.ProductId))
                .ForCtorParam(
                    "ProductName",
                    opt => opt.MapFrom(src => src.Product!.Name))
                .ForCtorParam(
                    "RequestedQuantity",
                    opt => opt.MapFrom(src => src.RequestedQuantity))
                .ForCtorParam(
                    "ApprovedQuantity",
                    opt => opt.MapFrom(src => src.ApprovedQuantity))
                .ForCtorParam(
                    "ActualQuantity",
                    opt => opt.MapFrom(src => src.ActualQuantity));

            CreateMap<Order, OrderResponse>();
        }
    }
}
