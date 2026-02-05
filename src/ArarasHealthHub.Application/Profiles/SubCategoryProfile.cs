using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.SubCategories.Commands.CreateSubCategory;
using ArarasHealthHub.Application.Features.SubCategories.Commands.UpdateSubCategory;
using ArarasHealthHub.Application.Features.SubCategories.Dtos;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Core.Dtos;

using AutoMapper;

namespace ArarasHealthHub.Application.Profiles
{
    public class SubCategoryProfile : Profile
    {
        public SubCategoryProfile()
        {
            CreateMap<SubCategory, DropdownItemDto>();

            CreateMap<SubCategory, SubCategoryDto>()
                .ForMember(dest => dest.MainCategoryName,
                    opt => opt.MapFrom(src => src.MainCategory!.Name));

            CreateMap<CreateSubCategoryCommand, SubCategory>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedOn, opt => opt.Ignore())
                .ForMember(dest => dest.IsActive, opt => opt.Ignore())
                .ForMember(dest => dest.MainCategory, opt => opt.Ignore());

            CreateMap<UpdateSubCategoryCommand, SubCategory>()
                .ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedOn, opt => opt.Ignore())
                .ForMember(dest => dest.IsActive, opt => opt.Ignore())
                .ForMember(dest => dest.MainCategory, opt => opt.Ignore());
        }
    }
}
