using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.PresentationForms.Commands.UpdatePresentationForm;
using FluentValidation;

namespace ArarasHealthHub.Application.Features.PresentationForms.Validation
{
    public class UpdatePresentationFormCommandValidator : AbstractValidator<UpdatePresentationFormCommand>
    {
        public UpdatePresentationFormCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("O identificador da categoria principal é inválido.");

            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithMessage("O nome é obrigatório.")
                .MaximumLength(100)
                    .WithMessage("O nome não pode exceder 100 caracteres.");
        }
    }
}
