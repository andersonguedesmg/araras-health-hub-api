using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Shared.Responses;

using MediatR;

namespace ArarasHealthHub.Application.Features.Accounts.Commands.DeactivateAccount
{
    public sealed record DeactivateAccountCommand(int Id) : IRequest<ApiResponse<object>>
    {
        public DeactivateAccountCommand WithId(int id)
            => this with { Id = id };
    }
}
