using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.PresentationForms.Commands.CreatePresentationForm;
using ArarasHealthHub.Application.Features.PresentationForms.Commands.UpdatePresentationForm;
using ArarasHealthHub.Application.Features.PresentationForms.Dtos;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Dtos;

using AutoMapper;

namespace ArarasHealthHub.Application.Profiles
{
    public class PresentationFormProfile : Profile
    {
        public PresentationFormProfile()
        {
            CreateMap<PresentationForm, PresentationFormDto>();
            CreateMap<PresentationForm, DropdownItemDto>();

            CreateMap<CreatePresentationFormCommand, PresentationForm>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedOn, opt => opt.Ignore())
                .ForMember(dest => dest.IsActive, opt => opt.Ignore());

            CreateMap<UpdatePresentationFormCommand, PresentationForm>()
                .ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedOn, opt => opt.Ignore())
                .ForMember(dest => dest.IsActive, opt => opt.Ignore());
        }
    }
}
