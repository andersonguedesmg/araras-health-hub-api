using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.MainCategories.Commands.CreateMainCategory;
using ArarasHealthHub.Application.Features.MainCategories.Commands.UpdateMainCategory;
using ArarasHealthHub.Application.Features.MainCategories.Dtos;
using ArarasHealthHub.Domain.Entities;
using AutoMapper;

namespace ArarasHealthHub.Application.Profiles
{
    public class MainCategoryProfile : Profile
    {
        public MainCategoryProfile()
        {
            CreateMap<MainCategory, MainCategoryDto>();
            CreateMap<MainCategory, MainCategoryNameDto>();

            CreateMap<CreateMainCategoryCommand, MainCategory>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedOn, opt => opt.Ignore())
                .ForMember(dest => dest.IsActive, opt => opt.Ignore());

            CreateMap<UpdateMainCategoryCommand, MainCategory>()
                .ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedOn, opt => opt.Ignore())
                .ForMember(dest => dest.IsActive, opt => opt.Ignore());
        }
    }
}
