using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Accounts.Dtos;
using ArarasHealthHub.Shared.Core.Requests;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;

namespace ArarasHealthHub.Application.Features.Accounts.Queries.GetAllAccounts
{
    public class GetAllAccountsQuery : PagedRequest, IRequest<PagedResponse<AccountDetailsDto>>
    {
        public string? SearchTerm { get; set; }
    }
}
