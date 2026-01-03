using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.PresentationForms.Commands.ChangeStatusPresentationForm;
using FluentValidation;

namespace ArarasHealthHub.Application.Features.PresentationForms.Validation
{
    public class ChangeStatusPresentationFormCommandValidator : AbstractValidator<ChangeStatusPresentationFormCommand>
    {
        public ChangeStatusPresentationFormCommandValidator()
        {
            RuleFor(command => command.Id)
                .GreaterThan(0).WithMessage("O ID da Forma de Apresentação é inválido para alterar o status.");

            RuleFor(command => command.IsActive)
                .NotNull().WithMessage("O status 'IsActive' é obrigatório.");
        }
    }
}
