using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.SubCategories.Responses;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Responses;

using AutoMapper;

namespace ArarasHealthHub.Application.Profiles
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<Supplier, SupplierResponse>();

            CreateMap<Supplier, SupplierListItemResponse>();

            CreateMap<Supplier, DropdownItemResponse>()
                .ForCtorParam("Label", opt => opt.MapFrom(src => src.TradeName));
        }
    }
}
