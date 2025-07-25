using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Accounts.Dtos;
using ArarasHealthHub.Application.Features.Facilities.Commands.CreateFacility;
using ArarasHealthHub.Application.Features.Facilities.Commands.UpdateFacility;
using ArarasHealthHub.Application.Features.Facilities.Dtos;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Domain.Identity;
using AutoMapper;

namespace ArarasHealthHub.Application.Profiles
{
    public class FacilityProfile : Profile
    {
        public FacilityProfile()
        {
            CreateMap<Facility, FacilityDto>();
            CreateMap<Facility, FacilityNameDto>();

            CreateMap<ApplicationUser, AccountDto>();

            CreateMap<CreateFacilityCommand, Facility>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedOn, opt => opt.Ignore())
                .ForMember(dest => dest.IsActive, opt => opt.Ignore());

            CreateMap<UpdateFacilityCommand, Facility>()
                .ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedOn, opt => opt.Ignore())
                .ForMember(dest => dest.IsActive, opt => opt.Ignore());
        }
    }
}
