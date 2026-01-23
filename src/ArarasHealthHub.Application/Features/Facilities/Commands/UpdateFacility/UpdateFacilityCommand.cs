using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Common.Dtos;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;

namespace ArarasHealthHub.Application.Features.Facilities.Commands.UpdateFacility
{
    public record UpdateFacilityCommand(
        int Id,
        string Name,
        string Cnes,
        AddressDto Address,
        ContactDto Contact
    ) : IRequest<ApiResponse<object>>
    {
        public UpdateFacilityCommand WithId(int id)
            => this with { Id = id };
    }
}
