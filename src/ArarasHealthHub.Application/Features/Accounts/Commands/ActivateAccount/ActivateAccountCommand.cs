using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Shared.Core.Responses;

using MediatR;

namespace ArarasHealthHub.Application.Features.Accounts.Commands.ActivateAccount
{
    public sealed record ActivateAccountCommand(int Id) : IRequest<ApiResponse<object>>
    {
        public ActivateAccountCommand WithId(int id)
            => this with { Id = id };
    }
}
