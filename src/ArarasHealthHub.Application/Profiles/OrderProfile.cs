using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Orders.Responses;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Responses;

using AutoMapper;

namespace ArarasHealthHub.Application.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderItem, OrderItemResponse>();

            CreateMap<Facility, DropdownItemResponse>()
                .ForCtorParam("Label", opt => opt.MapFrom(src => src.Name));

            CreateMap<Employee, DropdownItemResponse>()
                .ForCtorParam("Label", opt => opt.MapFrom(src => src.Name));

            CreateMap<Order, OrderResponse>();
        }
    }
}
