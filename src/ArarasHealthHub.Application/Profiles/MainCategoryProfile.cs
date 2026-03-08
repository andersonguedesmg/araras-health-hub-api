using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.MainCategories.Responses;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Responses;

using AutoMapper;

namespace ArarasHealthHub.Application.Profiles
{
    public class MainCategoryProfile : Profile
    {
        public MainCategoryProfile()
        {
            CreateMap<MainCategory, MainCategoryResponse>();

            CreateMap<MainCategory, MainCategoryListItemResponse>();

            CreateMap<MainCategory, DropdownItemResponse>();
        }
    }
}
