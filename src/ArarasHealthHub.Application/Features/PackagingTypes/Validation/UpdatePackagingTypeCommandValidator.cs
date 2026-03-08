using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.PackagingTypes.Commands.UpdatePackagingType;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.PackagingTypes.Validation
{
    public class UpdatePackagingTypeCommandValidator : AbstractValidator<UpdatePackagingTypeCommand>
    {
        public UpdatePackagingTypeCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Identificador inválido.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Nome é obrigatório.")
                .MaximumLength(100).WithMessage("Nome não pode exceder 100 caracteres.");
        }
    }
}
