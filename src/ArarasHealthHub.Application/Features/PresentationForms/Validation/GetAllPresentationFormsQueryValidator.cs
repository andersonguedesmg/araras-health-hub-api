using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.PresentationForms.Queries.GetAllPresentationForms;
using ArarasHealthHub.Shared.Messages;
using ArarasHealthHub.Shared.Pagination;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.PresentationForms.Validation
{
    public class GetAllPresentationFormsQueryValidator : PagedQueryValidator<GetAllPresentationFormsQuery>
    {
        public GetAllPresentationFormsQueryValidator()
        {
            RuleFor(x => x.OrderBy)
                .Must(x => x is null ||
                        x.ToLower() is "name")
                .WithMessage(ValidationMessages.InvalidOrderBy);
        }
    }
}
