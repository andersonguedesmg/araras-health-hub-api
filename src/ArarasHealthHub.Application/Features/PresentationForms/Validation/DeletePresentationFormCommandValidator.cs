using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.PresentationForms.Commands.DeletePresentationForm;
using FluentValidation;

namespace ArarasHealthHub.Application.Features.PresentationForms.Validation
{
    public class DeletePresentationFormCommandValidator : AbstractValidator<DeletePresentationFormCommand>
    {
        public DeletePresentationFormCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("O identificador da forma de apresentação é inválido.");
        }
    }
}
