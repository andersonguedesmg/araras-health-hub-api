using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Facilities.Commands.DeactivateFacility
{
    public record DeactivateFacilityCommand(int Id) : IRequest<Result>;
}
