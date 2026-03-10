using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Accounts.Commands.ChangeAccountPassword
{
    public sealed record ChangeAccountPasswordCommand(
        int TargetUserId,
        string NewPassword
    ) : IRequest<Result>;
}
