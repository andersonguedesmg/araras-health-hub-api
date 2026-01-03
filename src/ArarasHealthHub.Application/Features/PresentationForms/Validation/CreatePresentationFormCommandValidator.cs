using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.PresentationForms.Commands.CreatePresentationForm;
using ArarasHealthHub.Application.Interfaces.Repositories;
using FluentValidation;

namespace ArarasHealthHub.Application.Features.PresentationForms.Validation
{
    public class CreatePresentationFormCommandValidator : AbstractValidator<CreatePresentationFormCommand>
    {
        private readonly IPresentationFormRepository _presentationFormRepository;

        public CreatePresentationFormCommandValidator(IPresentationFormRepository presentationFormRepository)
        {
            _presentationFormRepository = presentationFormRepository;

            RuleFor(command => command.Name)
                .NotEmpty().WithMessage("O nome da Forma de Apresentação é obrigatório.")
                .MaximumLength(100).WithMessage("O nome da Forma de Apresentação não pode exceder 100 caracteres.");
        }
    }
}
