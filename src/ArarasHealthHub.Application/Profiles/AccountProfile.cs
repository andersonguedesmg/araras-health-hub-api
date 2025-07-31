using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Accounts.Dtos;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Domain.Identity;
using AutoMapper;

namespace ArarasHealthHub.Application.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<ApplicationUser, AccountDetailsDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Roles, opt => opt.Ignore());

            CreateMap<Facility, FacilityDetailsDto>();
        }
    }
}
