using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.PresentationForms.Queries.GetPresentationFormById;
using FluentValidation;

namespace ArarasHealthHub.Application.Features.PresentationForms.Validation
{
    public class GetPresentationFormByIdQueryValidator : AbstractValidator<GetPresentationFormByIdQuery>
    {
        public GetPresentationFormByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("O identificador da forma de apresentação é inválido.");
        }
    }
}
