using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.ValueObjects;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Facilities.Commands.CreateFacility
{
    public record CreateFacilityCommand(
        string Name,
        string Cnes,
        Address Address,
        Contact Contact
    ) : IRequest<Result<int>>;
}
