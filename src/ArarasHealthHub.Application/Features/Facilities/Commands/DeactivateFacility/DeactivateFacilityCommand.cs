using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Shared.Core.Responses;

using MediatR;

namespace ArarasHealthHub.Application.Features.Facilities.Commands.DeactivateFacility
{
    public record DeactivateFacilityCommand(int Id) : IRequest<ApiResponse<object>>
    {
        public DeactivateFacilityCommand WithId(int id)
            => this with { Id = id };
    }
}
