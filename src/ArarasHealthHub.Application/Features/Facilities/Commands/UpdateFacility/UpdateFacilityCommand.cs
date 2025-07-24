using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Shared.Core;
using MediatR;

namespace ArarasHealthHub.Application.Features.Facilities.Commands.UpdateFacility
{
    public record UpdateFacilityCommand(
        int Id,
        string Name,
        string Address,
        string Number,
        string Neighborhood,
        string City,
        string State,
        string Cep,
        string Email,
        string Phone
    ) : IRequest<ApiResponse<bool>>;
}
