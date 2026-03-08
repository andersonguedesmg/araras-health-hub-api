using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.ValueObjects;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Facilities.Commands.UpdateFacility
{
    public record UpdateFacilityCommand(
        int Id,
        string Name,
        string Cnes,
        Address Address,
        Contact Contact
    ) : IRequest<Result>
    {
        public UpdateFacilityCommand WithId(int id)
            => this with { Id = id };
    }
}
