using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;

namespace ArarasHealthHub.Application.Features.Facilities.Commands.DeleteFacility
{
    public record DeleteFacilityCommand(int Id) : IRequest<ApiResponse<object>>
    {
        public DeleteFacilityCommand WithId(int id)
            => this with { Id = id };
    }
}
