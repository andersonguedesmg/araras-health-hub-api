using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.PresentationForms.Commands.ActivatePresentationForm;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.PresentationForms.Validation
{
    public class ActivatePresentationFormCommandValidator : AbstractValidator<ActivatePresentationFormCommand>
    {
        public ActivatePresentationFormCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Identificador inválido.");
        }
    }
}
