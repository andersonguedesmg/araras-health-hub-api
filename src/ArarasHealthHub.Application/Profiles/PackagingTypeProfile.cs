using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.PackagingTypes.Responses;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Responses;

using AutoMapper;

namespace ArarasHealthHub.Application.Profiles
{
    public class PackagingTypeProfile : Profile
    {
        public PackagingTypeProfile()
        {
            CreateMap<PackagingType, PackagingTypeResponse>();

            CreateMap<PackagingType, PackagingTypeListItemResponse>();

            CreateMap<PackagingType, DropdownItemResponse>()
                .ForCtorParam("Label", opt => opt.MapFrom(src => src.Name));
        }
    }
}
