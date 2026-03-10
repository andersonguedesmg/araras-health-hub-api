using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Accounts.Responses;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Accounts.Commands.LoginAccount
{
    public sealed record LoginAccountCommand(
        string UserName,
        string Password
    ) : IRequest<Result<LoginAccountResponse>>;
}
