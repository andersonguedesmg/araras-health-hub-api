using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Suppliers.Commands.CreateSupplier;
using ArarasHealthHub.Application.Features.Suppliers.Commands.UpdateSupplier;
using ArarasHealthHub.Application.Features.Suppliers.Dtos;
using ArarasHealthHub.Domain.Entities;
using AutoMapper;

namespace ArarasHealthHub.Application.Features.Suppliers.Profiles
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<Supplier, SupplierDto>();

            CreateMap<CreateSupplierCommand, Supplier>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedOn, opt => opt.Ignore())
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true));

            CreateMap<UpdateSupplierCommand, Supplier>()
                .ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedOn, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.IsActive, opt => opt.Ignore());
        }
    }
}
