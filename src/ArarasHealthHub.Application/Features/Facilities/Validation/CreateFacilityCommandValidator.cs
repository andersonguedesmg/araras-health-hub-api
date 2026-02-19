using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Common.Validation;
using ArarasHealthHub.Application.Features.Facilities.Commands.CreateFacility;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Messages;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.Facilities.Validation
{
    public class CreateFacilityCommandValidator : AbstractValidator<CreateFacilityCommand>
    {
        private readonly IFacilityRepository _facilityRepository;

        public CreateFacilityCommandValidator(IFacilityRepository facilityRepository)
        {
            _facilityRepository = facilityRepository;

            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithName("Nome")
                    .WithMessage(ValidationMessages.RequiredField)
                .MaximumLength(100)
                    .WithMessage(ValidationMessages.MaxLengthField(100))
                .MustAsync(BeUniqueName)
                    .WithMessage("Já existe uma unidade cadastrada com este nome.");

            RuleFor(x => x.Cnes)
                .NotEmpty()
                    .WithName("CNES")
                    .WithMessage(ValidationMessages.RequiredField)
                .MaximumLength(7)
                    .WithMessage(ValidationMessages.MaxLengthField(7));

            RuleFor(x => x.Address)
                .NotNull()
                    .WithName("endereço")
                    .WithMessage(ValidationMessages.RequiredObject)
                .SetValidator(new AddressDtoValidator());

            RuleFor(x => x.Contact)
                .NotNull()
                    .WithName("contato")
                    .WithMessage(ValidationMessages.RequiredObject)
                .SetValidator(new ContactDtoValidator());
        }

        private async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
        {
            var existingFacility = await _facilityRepository.GetByNameAsync(name, cancellationToken);
            return existingFacility == null;
        }
    }
}
