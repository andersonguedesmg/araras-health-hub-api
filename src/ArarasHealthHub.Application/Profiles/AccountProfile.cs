using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Accounts.Responses;
using ArarasHealthHub.Application.Features.Facilities.Responses;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Domain.Identity;

using AutoMapper;

namespace ArarasHealthHub.Application.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<ApplicationUser, AccountResponse>()
                .ForCtorParam("UserId", opt => opt.MapFrom(src => src.Id))
                .ForCtorParam("UserName", opt => opt.MapFrom(src => src.UserName))
                .ForCtorParam("IsActive", opt => opt.MapFrom(src => src.IsActive))
                .ForCtorParam("Scope", opt => opt.MapFrom(src => src.Scope))
                .ForCtorParam("Role", opt => opt.MapFrom(src => src.Role))
                .ForCtorParam("CreatedOn", opt => opt.MapFrom(src => src.CreatedOn))
                .ForCtorParam("UpdatedOn", opt => opt.MapFrom(src => src.UpdatedOn))
                .ForCtorParam("Facility", opt => opt.MapFrom(src => src.Facility));

            CreateMap<Facility, FacilityResponse>()
                .ForCtorParam("Id", opt => opt.MapFrom(src => src.Id))
                .ForCtorParam("Name", opt => opt.MapFrom(src => src.Name))
                .ForCtorParam("Cnes", opt => opt.MapFrom(src => src.Cnes))
                .ForCtorParam("Cep", opt => opt.MapFrom(src => src.Address.Cep))
                .ForCtorParam("Street", opt => opt.MapFrom(src => src.Address.Street))
                .ForCtorParam("Number", opt => opt.MapFrom(src => src.Address.Number))
                .ForCtorParam("Complement", opt => opt.MapFrom(src => src.Address.Complement))
                .ForCtorParam("Neighborhood", opt => opt.MapFrom(src => src.Address.Neighborhood))
                .ForCtorParam("City", opt => opt.MapFrom(src => src.Address.City))
                .ForCtorParam("State", opt => opt.MapFrom(src => src.Address.State))
                .ForCtorParam("Email", opt => opt.MapFrom(src => src.Contact.Email))
                .ForCtorParam("Phone", opt => opt.MapFrom(src => src.Contact.Phone));
        }
    }
}
