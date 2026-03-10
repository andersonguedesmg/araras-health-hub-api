using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Facilities.Responses;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Responses;

using AutoMapper;

namespace ArarasHealthHub.Application.Profiles
{
    public class FacilityProfile : Profile
    {
        public FacilityProfile()
        {
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

            CreateMap<Facility, DropdownItemResponse>();
        }
    }
}
