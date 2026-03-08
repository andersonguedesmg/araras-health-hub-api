using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.PackagingTypes.Commands.CreatePackagingType;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.PackagingTypes.Validation
{
    public class CreatePackagingTypeCommandValidator : AbstractValidator<CreatePackagingTypeCommand>
    {
        public CreatePackagingTypeCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Nome é obrigatório.")
                .MaximumLength(100).WithMessage("Nome não pode exceder 100 caracteres.");
        }
    }
}
