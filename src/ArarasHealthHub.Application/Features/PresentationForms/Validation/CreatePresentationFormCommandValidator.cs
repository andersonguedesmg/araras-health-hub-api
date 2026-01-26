using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.PresentationForms.Commands.CreatePresentationForm;
using FluentValidation;

namespace ArarasHealthHub.Application.Features.PresentationForms.Validation
{
    public class CreatePresentationFormCommandValidator : AbstractValidator<CreatePresentationFormCommand>
    {
        public CreatePresentationFormCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithMessage("O nome é obrigatório.")
                .MaximumLength(100)
                    .WithMessage("O nome não pode exceder 100 caracteres.");
        }
    }
}
