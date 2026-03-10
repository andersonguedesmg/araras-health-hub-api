using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Accounts.Responses;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Accounts.Queries.GetAccountById
{
    public sealed record GetAccountByIdQuery(
        int UserId
    ) : IRequest<Result<AccountResponse>>;
}
