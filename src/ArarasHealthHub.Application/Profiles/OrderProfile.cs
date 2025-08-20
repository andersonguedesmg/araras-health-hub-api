using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Accounts.Dtos;
using ArarasHealthHub.Application.Features.Employees.Dtos;
using ArarasHealthHub.Application.Features.Facilities.Dtos;
using ArarasHealthHub.Application.Features.Orders.Dtos;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Domain.Identity;
using AutoMapper;

namespace ArarasHealthHub.Application.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Employee, EmployeeNameDto>();
            CreateMap<Facility, FacilityNameDto>();

            CreateMap<ApplicationUser, AccountNameDto>();

            CreateMap<OrderStatus, OrderStatusDto>();

            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product!.Name))
                .ForMember(dest => dest.RequestedQuantity, opt => opt.MapFrom(src => src.RequestedQuantity))
                .ForMember(dest => dest.ApprovedQuantity, opt => opt.MapFrom(src => src.ApprovedQuantity))
                .ForMember(dest => dest.ActualQuantity, opt => opt.MapFrom(src => src.ActualQuantity));

            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems))
                .ForMember(dest => dest.OrderStatus, opt => opt.MapFrom(src => src.OrderStatus))
                .ForMember(dest => dest.CreatedByEmployee, opt => opt.MapFrom(src => src.CreatedByEmployee))
                .ForMember(dest => dest.CreatedByAccount, opt => opt.MapFrom(src => src.CreatedByAccount))
                .ForMember(dest => dest.ApprovedByEmployee, opt => opt.MapFrom(src => src.ApprovedByEmployee))
                .ForMember(dest => dest.ApprovedByAccount, opt => opt.MapFrom(src => src.ApprovedByAccount))
                .ForMember(dest => dest.SeparatedByEmployee, opt => opt.MapFrom(src => src.SeparatedByEmployee))
                .ForMember(dest => dest.SeparatedByAccount, opt => opt.MapFrom(src => src.SeparatedByAccount))
                .ForMember(dest => dest.FinalizedByEmployee, opt => opt.MapFrom(src => src.FinalizedByEmployee))
                .ForMember(dest => dest.FinalizedByAccount, opt => opt.MapFrom(src => src.FinalizedByAccount));
        }
    }
}
