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
                .NotEmpty().WithMessage("Nome é obrigatório.")
                .MaximumLength(100).WithMessage("Nome não pode exceder 100 caracteres.");
        }
    }
}
