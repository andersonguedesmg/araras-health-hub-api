using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Accounts.Dtos;
using MediatR;

namespace ArarasHealthHub.Application.Features.Accounts.Queries.ExportAccounts
{
    public class ExportAccountsQuery : IRequest<IEnumerable<AccountDetailsDto>>
    {
        public string? SearchTerm { get; set; }
    }
}
