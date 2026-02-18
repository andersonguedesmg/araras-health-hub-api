using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Accounts.Queries.GetAllAccounts;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Pagination;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.Accounts.Validation
{
    public class GetAllAccountsQueryValidator : PagedQueryValidator<GetAllAccountsQuery>
    {
        public GetAllAccountsQueryValidator()
        {
            RuleFor(x => x.OrderBy)
                .Must(x => x is null ||
                    x.ToLower() is "id" or "username" or "scope" or "role" or "createdon")
                .WithMessage(ValidationMessages.InvalidOrderBy);
        }
    }
}
