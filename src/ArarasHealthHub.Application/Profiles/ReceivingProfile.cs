using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Receivings.Commands.CreateReceiving;
using ArarasHealthHub.Application.Features.Receivings.Dtos;
using ArarasHealthHub.Domain.Entities;
using AutoMapper;

namespace ArarasHealthHub.Application.Profiles
{
    public class ReceivingProfile : Profile
    {
        public ReceivingProfile()
        {
            CreateMap<Receiving, ReceivingDto>()
                .ForMember(dest => dest.ReceivedItem, opt => opt.MapFrom(src => src.ReceivedItem));

            CreateMap<ReceivedItem, ReceivedItemDto>();

            CreateMap<CreateReceivingCommand, Receiving>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ReceivedItem, opt => opt.Ignore());

            CreateMap<CreateReceivedItemCommand, ReceivedItem>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ReceivingId, opt => opt.Ignore())
                .ForMember(dest => dest.TotalValue, opt => opt.Ignore());
        }
    }
}
