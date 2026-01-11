using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Common.Helpers;
using ArarasHealthHub.Application.Features.Employees.Commands.CreateEmployee;
using ArarasHealthHub.Application.Interfaces.Repositories;
using FluentValidation;

namespace ArarasHealthHub.Application.Features.Employees.Validation
{
    public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public CreateEmployeeCommandValidator(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;

            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithMessage("O nome é obrigatório.")
                .MaximumLength(100)
                    .WithMessage("O nome não pode exceder 100 caracteres.");

            RuleFor(x => x.Cpf)
                .NotEmpty()
                    .WithMessage("O CPF é obrigatório.")
                .Matches(@"^\d{3}\.\d{3}\.\d{3}\-\d{2}$")
                    .WithMessage("O CPF deve estar no formato XXX.XXX.XXX-XX.")
                .Must(CpfValidatorHelper.IsValidCpf)
                    .WithMessage("O CPF informado não é válido.")
                .MustAsync(BeUniqueCpf)
                    .WithMessage("Já existe um funcionário cadastrado com este CPF.");

            RuleFor(x => x.Function)
                .NotEmpty()
                    .WithMessage("A função é obrigatória.")
                .MaximumLength(100)
                    .WithMessage("A função não pode exceder 100 caracteres.");

            RuleFor(x => x.Phone)
                .NotEmpty()
                    .WithMessage("O telefone é obrigatório.")
                .MaximumLength(20)
                    .WithMessage("O telefone não pode exceder 20 caracteres.")
                .Matches(@"^\d{10,11}$|^(\+\d{1,3}\s?)?(\(?\d{2}\)?\s?\d{4,5}-?\d{4})$")
                    .WithMessage("O telefone informado não possui um formato válido.");
        }

        private async Task<bool> BeUniqueCpf(
            string cpf,
            CancellationToken cancellationToken)
        {
            var existingEmployee = await _employeeRepository.GetByCpfAsync(cpf);
            return existingEmployee is null;
        }
    }
}
