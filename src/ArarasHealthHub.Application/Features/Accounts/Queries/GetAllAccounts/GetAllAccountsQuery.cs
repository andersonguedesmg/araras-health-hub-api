using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Accounts.Responses;
using ArarasHealthHub.Shared.Pagination;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Accounts.Queries.GetAllAccounts
{
    public sealed class GetAllAccountsQuery : PagedRequest, IRequest<PagedResult<AccountListItemResponse>> { }
}
