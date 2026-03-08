using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Common.Validation;
using ArarasHealthHub.Application.Features.Facilities.Commands.UpdateFacility;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.Facilities.Validation
{
    public class UpdateFacilityCommandValidator : AbstractValidator<UpdateFacilityCommand>
    {
        public UpdateFacilityCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Identificador inválido.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Nome é obrigatório.")
                .MinimumLength(3).WithMessage("Nome deve ter pelo menos 3 caracteres.")
                .MaximumLength(100).WithMessage("Nome não pode exceder 100 caracteres.");

            RuleFor(x => x.Cnes)
                .NotEmpty().WithMessage("Código CNES é obrigatório.")
                .MaximumLength(7).WithMessage("Código CNES não pode exceder 7 caracteres.");

            RuleFor(x => x.Address)
                .NotNull().WithMessage("O endereço é obrigatório.")
                .SetValidator(new AddressRequestValidator());

            RuleFor(x => x.Contact)
                .NotNull().WithMessage("O contato é obrigatório.")
                .SetValidator(new ContactRequestValidator());
        }
    }
}
