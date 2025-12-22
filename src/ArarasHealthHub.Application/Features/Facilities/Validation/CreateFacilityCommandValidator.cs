using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Common.Validation;
using ArarasHealthHub.Application.Features.Facilities.Commands.CreateFacility;
using ArarasHealthHub.Application.Interfaces.Repositories;
using FluentValidation;

namespace ArarasHealthHub.Application.Features.Facilities.Validation
{
    public class CreateFacilityCommandValidator : AbstractValidator<CreateFacilityCommand>
    {
        private readonly IFacilityRepository _facilityRepository;

        public CreateFacilityCommandValidator(IFacilityRepository facilityRepository)
        {
            _facilityRepository = facilityRepository;

            RuleFor(command => command.Name)
                .NotEmpty().WithMessage("O nome da unidade é obrigatório.")
                .MaximumLength(100).WithMessage("O nome da unidade não pode exceder 100 caracteres.")
                .MustAsync(BeUniqueName).WithMessage("Já existe uma unidade cadastrada com este nome.");

            RuleFor(command => command.Cnes)
                .NotEmpty().WithMessage("O código CNES é obrigatório.")
                .MaximumLength(7).WithMessage("O código CNES não pode exceder 7 dígitos.");

            RuleFor(command => command.Address)
                .NotNull().WithMessage("O objeto de endereço é obrigatório.")
                .SetValidator(new AddressDtoValidator());

            RuleFor(command => command.Contact)
                .NotNull().WithMessage("O objeto de contato é obrigatório.")
                .SetValidator(new ContactDtoValidator());
        }

        private async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
        {
            var existingFacility = await _facilityRepository.GetByNameAsync(name);
            return existingFacility == null;
        }
    }
}
