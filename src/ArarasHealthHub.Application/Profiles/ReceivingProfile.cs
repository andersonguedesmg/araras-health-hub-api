using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Receivings.Responses;
using ArarasHealthHub.Domain.Entities;

using AutoMapper;

namespace ArarasHealthHub.Application.Profiles
{
    public class ReceivingProfile : Profile
    {
        public ReceivingProfile()
        {
            CreateMap<Receiving, ReceivingResponse>();

            CreateMap<ReceivedItem, ReceivingItemResponse>();
        }
    }
}
