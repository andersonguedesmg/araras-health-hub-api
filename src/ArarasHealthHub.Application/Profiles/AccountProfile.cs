using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Common.Responses;
using ArarasHealthHub.Application.Features.Accounts.Responses;
using ArarasHealthHub.Application.Features.Facilities.Responses;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Domain.Identity;
using ArarasHealthHub.Domain.ValueObjects;

using AutoMapper;

namespace ArarasHealthHub.Application.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<ApplicationUser, AccountResponse>();

            CreateMap<Address, AddressResponse>();
            CreateMap<Contact, ContactResponse>();

            CreateMap<Facility, FacilityResponse>();
        }
    }
}
