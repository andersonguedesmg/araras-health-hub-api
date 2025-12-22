using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Common.Dtos;
using ArarasHealthHub.Shared.Core;
using MediatR;

namespace ArarasHealthHub.Application.Features.Facilities.Commands.CreateFacility
{
    public record CreateFacilityCommand(
        string Name,
        string Cnes,
        AddressDto Address,
        ContactDto Contact
    ) : IRequest<ApiResponse<int>>;
}
