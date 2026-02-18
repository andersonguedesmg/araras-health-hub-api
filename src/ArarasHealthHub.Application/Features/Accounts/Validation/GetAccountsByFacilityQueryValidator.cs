using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Accounts.Queries.GetAccountsByFacility;
using ArarasHealthHub.Shared.Core.Messages;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.Accounts.Validation
{
    public class GetAccountsByFacilityQueryValidator : AbstractValidator<GetAccountsByFacilityQuery>
    {
        public GetAccountsByFacilityQueryValidator()
        {
            RuleFor(x => x.FacilityId)
                .GreaterThan(0)
                .WithMessage(ValidationMessages.InvalidId);
        }
    }
}
