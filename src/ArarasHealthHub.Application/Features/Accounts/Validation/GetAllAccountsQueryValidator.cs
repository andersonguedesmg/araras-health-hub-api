using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Accounts.Queries.GetAllAccounts;
using ArarasHealthHub.Shared.Pagination;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.Accounts.Validation
{
    public class GetAllAccountsQueryValidator : PagedQueryValidator<GetAllAccountsQuery>
    {
        public GetAllAccountsQueryValidator()
        {
            RuleFor(x => x.OrderBy)
                .Must(x => x is null ||
                        x.Equals("username", StringComparison.OrdinalIgnoreCase) ||
                        x.Equals("scope", StringComparison.OrdinalIgnoreCase) ||
                        x.Equals("role", StringComparison.OrdinalIgnoreCase))
                .WithMessage("Campo de ordenação inválido.");
        }
    }
}
