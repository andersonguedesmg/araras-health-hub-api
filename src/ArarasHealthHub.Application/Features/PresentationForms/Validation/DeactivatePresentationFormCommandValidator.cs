using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.PresentationForms.Commands.DeactivatePresentationForm;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.PresentationForms.Validation
{
    public class DeactivatePresentationFormCommandValidator : AbstractValidator<DeactivatePresentationFormCommand>
    {
        public DeactivatePresentationFormCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Identificador inválido.");
        }
    }
}
