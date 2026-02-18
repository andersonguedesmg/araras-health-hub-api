using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Accounts.Dtos;
using ArarasHealthHub.Shared.Core.Responses;

using MediatR;

namespace ArarasHealthHub.Application.Features.Accounts.Queries.GetAccountById
{
    public sealed record GetAccountByIdQuery(
        int UserId
    ) : IRequest<ApiResponse<GetAccountByIdResponse>>;
}
