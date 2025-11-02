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
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => !src.LockoutEnd.HasValue || src.LockoutEnd.Value.ToUniversalTime() < DateTime.UtcNow))
                .ForMember(dest => dest.Roles, opt => opt.Ignore())
                .ForMember(dest => dest.Facility, opt => opt.Ignore());

            CreateMap<Facility, FacilityDetailsDto>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address.Street))
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Address.Number))
                .ForMember(dest => dest.Neighborhood, opt => opt.MapFrom(src => src.Address.Neighborhood))
                .ForMember(dest => dest.Cep, opt => opt.MapFrom(src => src.Address.Cep))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Contact.Email))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Contact.Phone));
        }
    }
}
