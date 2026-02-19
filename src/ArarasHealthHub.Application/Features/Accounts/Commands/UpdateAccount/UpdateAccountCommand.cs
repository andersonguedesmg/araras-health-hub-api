using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Shared.Responses;

using MediatR;

namespace ArarasHealthHub.Application.Features.Accounts.Commands.UpdateAccount
{
    public record UpdateAccountCommand(
        int UserId,
        string UserName
    ) : IRequest<ApiResponse<object>>
    {
        public UpdateAccountCommand WithId(int id)
            => this with { UserId = id };
    }
}
