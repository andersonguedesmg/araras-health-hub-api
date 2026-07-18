using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Common.Responses;
using ArarasHealthHub.Application.Features.Facilities.Responses;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Domain.ValueObjects;
using ArarasHealthHub.Shared.Responses;

using AutoMapper;

namespace ArarasHealthHub.Application.Profiles
{
    public class FacilityProfile : Profile
    {
        public FacilityProfile()
        {
            CreateMap<Address, AddressResponse>();
            CreateMap<Contact, ContactResponse>();

            CreateMap<Facility, FacilityResponse>();

            CreateMap<Facility, DropdownItemResponse>()
                .ForCtorParam("Label", opt => opt.MapFrom(src => src.Name));
        }
    }
}
