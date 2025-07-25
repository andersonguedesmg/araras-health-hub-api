using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

            RuleFor(command => command.Name)
                .NotEmpty().WithMessage("O nome da unidade é obrigatório.")
                .MaximumLength(100).WithMessage("O nome da unidade não pode exceder 100 caracteres.")
                .MustAsync(BeUniqueName).WithMessage("Já existe uma unidade cadastrada com este nome.");

            RuleFor(command => command.Address)
                .NotEmpty().WithMessage("O endereço da unidade é obrigatório.")
                .MaximumLength(200).WithMessage("O endereço da unidade não pode exceder 200 caracteres.");

            RuleFor(command => command.Number)
                .NotEmpty().WithMessage("O número do endereço da unidade é obrigatório.")
                .MaximumLength(20).WithMessage("O número do endereço da unidade não pode exceder 20 caracteres.");

            RuleFor(command => command.Neighborhood)
                .NotEmpty().WithMessage("O bairro da unidade é obrigatório.")
                .MaximumLength(100).WithMessage("O bairro da unidade não pode exceder 100 caracteres.");

            RuleFor(command => command.City)
                .NotEmpty().WithMessage("A cidade da unidade é obrigatória.")
                .MaximumLength(100).WithMessage("A cidade da unidade não pode exceder 100 caracteres.");

            RuleFor(command => command.State)
                .NotEmpty().WithMessage("O estado da unidade é obrigatório.")
                .Length(2).WithMessage("O estado da unidade deve conter 2 caracteres (UF).")
                .Matches(@"^[A-Z]{2}$").WithMessage("O estado da unidade deve conter 2 letras maiúsculas (UF).");

            RuleFor(command => command.Cep)
                .NotEmpty().WithMessage("O CEP da unidade é obrigatório.")
                .Length(9).WithMessage("O CEP da unidade deve conter 9 dígitos.")
                .Matches(@"^\d{5}-\d{3}$").WithMessage("O CEP deve estar no formato 'XXXXX-XXX'.");

            RuleFor(command => command.Email)
                .NotEmpty().WithMessage("O email da unidade é obrigatório.")
                .EmailAddress().WithMessage("O formato do email da unidade é inválido.")
                .MaximumLength(100).WithMessage("O email da unidade não pode exceder 100 caracteres.");

            RuleFor(command => command.Phone)
                .NotEmpty().WithMessage("O telefone da unidade é obrigatório.")
                .MaximumLength(20).WithMessage("O telefone da unidade não pode exceder 20 caracteres.")
                .Matches(@"^\d{10,11}$|^(\+\d{1,3}\s?)?(\(?\d{2}\)?\s?\d{4,5}-?\d{4})$").WithMessage("O formato do telefone é inválido.");
        }

        private async Task<bool> BeUniqueName(UpdateFacilityCommand command, string name, CancellationToken cancellationToken)
        {
            var existingFacility = await _facilityRepository.GetByNameAsync(name);
            return existingFacility == null || existingFacility.Id == command.Id;
        }
    }
}
