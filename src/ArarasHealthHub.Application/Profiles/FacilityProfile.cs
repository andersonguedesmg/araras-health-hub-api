using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Common.Dtos;
using ArarasHealthHub.Application.Features.Facilities.Commands.CreateFacility;
using ArarasHealthHub.Application.Features.Facilities.Commands.UpdateFacility;
using ArarasHealthHub.Application.Features.Facilities.Dtos;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Domain.ValueObjects;
using ArarasHealthHub.Shared.Dtos;

using AutoMapper;

namespace ArarasHealthHub.Application.Profiles
{
    public class FacilityProfile : Profile
    {
        public FacilityProfile()
        {
            CreateMap<AddressDto, Address>().ReverseMap();
            CreateMap<ContactDto, Contact>().ReverseMap();

            CreateMap<Facility, FacilityDto>();
            CreateMap<Facility, DropdownItemDto>();

            CreateMap<CreateFacilityCommand, Facility>()
                .ForPath(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForPath(dest => dest.Contact, opt => opt.MapFrom(src => src.Contact))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedOn, opt => opt.Ignore())
                .ForMember(dest => dest.IsActive, opt => opt.Ignore());

            CreateMap<UpdateFacilityCommand, Facility>()
                .ForPath(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForPath(dest => dest.Contact, opt => opt.MapFrom(src => src.Contact))
                .ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedOn, opt => opt.Ignore())
                .ForMember(dest => dest.IsActive, opt => opt.Ignore());

            CreateMap<Facility, FacilityProfileDto>()
                .ForMember(dest => dest.FacilityAccounts, opt => opt.Ignore());
        }
    }
}
