using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Common.Validation;
using ArarasHealthHub.Application.Features.Facilities.Commands.UpdateFacility;
using ArarasHealthHub.Application.Interfaces.Repositories;
using FluentValidation;

namespace ArarasHealthHub.Application.Features.Facilities.Validation
{
    public class UpdateFacilityCommandValidator : AbstractValidator<UpdateFacilityCommand>
    {
        private readonly IFacilityRepository _facilityRepository;

        public UpdateFacilityCommandValidator(IFacilityRepository facilityRepository)
        {
            _facilityRepository = facilityRepository;

            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("O identificador do funcionário é inválido.");

            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithMessage("O nome é obrigatório.")
                .MaximumLength(100)
                    .WithMessage("O nome não pode exceder 100 caracteres.")
                .MustAsync(BeUniqueName)
                    .WithMessage("Já existe uma unidade cadastrada com este nome.");

            RuleFor(x => x.Cnes)
                .NotEmpty()
                    .WithMessage("O código CNES é obrigatório.")
                .MaximumLength(7)
                    .WithMessage("O código CNES não pode exceder 7 caracteres.");

            RuleFor(x => x.Address)
                .NotNull()
                    .WithMessage("O objeto de endereço é obrigatório.")
                .SetValidator(new AddressDtoValidator());

            RuleFor(x => x.Contact)
                .NotNull()
                    .WithMessage("O objeto de contato é obrigatório.")
                .SetValidator(new ContactDtoValidator());
        }

        private async Task<bool> BeUniqueName(UpdateFacilityCommand command, string name, CancellationToken cancellationToken)
        {
            var existingFacility = await _facilityRepository.GetByNameAsync(name);
            return existingFacility == null || existingFacility.Id == command.Id;
        }
    }
}
