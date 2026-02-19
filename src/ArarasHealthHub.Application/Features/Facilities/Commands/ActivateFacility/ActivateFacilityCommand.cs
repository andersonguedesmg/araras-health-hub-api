using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Shared.Responses;

using MediatR;

namespace ArarasHealthHub.Application.Features.Facilities.Commands.ActivateFacility
{
    public record ActivateFacilityCommand(int Id) : IRequest<ApiResponse<object>>
    {
        public ActivateFacilityCommand WithId(int id)
            => this with { Id = id };
    }
}
