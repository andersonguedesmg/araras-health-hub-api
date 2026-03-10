using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Accounts.Dtos;
using ArarasHealthHub.Application.Features.Orders.Dtos;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Domain.Identity;
using ArarasHealthHub.Shared.Responses;

using AutoMapper;

namespace ArarasHealthHub.Application.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Employee, DropdownItemResponse>();
            CreateMap<Facility, DropdownItemResponse>();
            CreateMap<ApplicationUser, AccountMinimalDto>();
            CreateMap<OrderStatus, OrderStatusDto>();

            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product!.Name))
                .ForMember(dest => dest.RequestedQuantity, opt => opt.MapFrom(src => src.RequestedQuantity))
                .ForMember(dest => dest.ApprovedQuantity, opt => opt.MapFrom(src => src.ApprovedQuantity))
                .ForMember(dest => dest.ActualQuantity, opt => opt.MapFrom(src => src.ActualQuantity))
                .ForMember(dest => dest.AvailableQuantity, opt => opt.MapFrom(src => src.Product!.Stock!.CurrentQuantity))
                .ForMember(dest => dest.LotsToSeparate, opt => opt.Ignore());

            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems))
                .ForMember(dest => dest.OrderStatus, opt => opt.MapFrom(src => src.OrderStatus))
                .ForMember(dest => dest.OrderFacility, opt => opt.MapFrom(src => src.OrderFacility))
                .ForMember(dest => dest.CreatedByEmployee, opt => opt.MapFrom(src => src.CreatedByEmployee))
                .ForMember(dest => dest.CreatedByAccount, opt => opt.MapFrom(src => src.CreatedByAccount))
                .ForMember(dest => dest.ApprovedByEmployee, opt => opt.MapFrom(src => src.ApprovedByEmployeeId))
                .ForMember(dest => dest.ApprovedByAccount, opt => opt.MapFrom(src => src.ApprovedByAccountId))
                .ForMember(dest => dest.SeparatedByEmployee, opt => opt.MapFrom(src => src.SeparatedByEmployeeId))
                .ForMember(dest => dest.SeparatedByAccount, opt => opt.MapFrom(src => src.SeparatedByAccountId))
                .ForMember(dest => dest.FinalizedByEmployee, opt => opt.MapFrom(src => src.FinalizedByEmployeeId))
                .ForMember(dest => dest.FinalizedByAccount, opt => opt.MapFrom(src => src.FinalizedByAccountId))
                .ForMember(dest => dest.FinalizedByEmployee, opt => opt.MapFrom(src => src.CanceledByEmployeeId))
                .ForMember(dest => dest.FinalizedByAccount, opt => opt.MapFrom(src => src.CanceledByAccountId));
        }
    }
}
