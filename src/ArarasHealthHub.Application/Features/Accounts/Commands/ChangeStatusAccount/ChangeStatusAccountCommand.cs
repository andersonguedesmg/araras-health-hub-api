using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Shared.Core;
using MediatR;

namespace ArarasHealthHub.Application.Features.Accounts.Commands.ChangeStatusAccount
{
    public record ChangeStatusAccountCommand(
        int UserId,
        bool IsActive
    ) : IRequest<ApiResponse<bool>>;
}
