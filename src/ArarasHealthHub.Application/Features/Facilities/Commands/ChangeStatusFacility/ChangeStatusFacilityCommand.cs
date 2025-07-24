using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Shared.Core;
using MediatR;

namespace ArarasHealthHub.Application.Features.Facilities.Commands.ChangeStatusFacility
{
    public record ChangeStatusFacilityCommand(
        int Id,
        bool IsActive
    ) : IRequest<ApiResponse<bool>>;
}
