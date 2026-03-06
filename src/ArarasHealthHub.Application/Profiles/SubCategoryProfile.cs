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
    public class SubCategoryProfile : Profile
    {
        public SubCategoryProfile()
        {
            CreateMap<SubCategory, DropdownItemResponse>();

            CreateMap<SubCategory, SubCategoryResponse>()
                .ForMember(dest => dest.MainCategoryName,
                    opt => opt.MapFrom(src => src.MainCategory!.Name));

            CreateMap<SubCategory, SubCategoryListItemResponse>()
                .ForMember(dest => dest.MainCategoryName,
                    opt => opt.MapFrom(src => src.MainCategory!.Name));
        }
    }
}
