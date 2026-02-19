using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.PresentationForms.Commands.CreatePresentationForm;
using ArarasHealthHub.Shared.Messages;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.PresentationForms.Validation
{
    public class CreatePresentationFormCommandValidator : AbstractValidator<CreatePresentationFormCommand>
    {
        public CreatePresentationFormCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithName("Nome")
                    .WithMessage(ValidationMessages.RequiredField)
                .MaximumLength(100)
                    .WithMessage(ValidationMessages.MaxLengthField(100));
        }
    }
}
