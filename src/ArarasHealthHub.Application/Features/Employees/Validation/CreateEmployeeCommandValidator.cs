using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

            RuleFor(command => command.Name)
                .NotEmpty().WithMessage("O nome do funcionário é obrigatório.")
                .MaximumLength(100).WithMessage("O nome do funcionário não pode exceder 100 caracteres.");

            RuleFor(command => command.Cpf)
                .NotEmpty().WithMessage("O CPF do funcionário é obrigatório.")
                .Length(14).WithMessage("O CPF do funcionário deve conter 14 dígitos.")
                .Matches(@"^\d{14}$").WithMessage("O CPF do funcionário deve conter apenas números.")
                .MustAsync(BeUniqueCpf).WithMessage("Já existe um funcionário cadastrado com este CPF.");

            RuleFor(command => command.Function)
                .NotEmpty().WithMessage("A função do funcionário é obrigatória.")
                .MaximumLength(100).WithMessage("A função do funcionário não pode exceder 100 caracteres.");

            RuleFor(command => command.Phone)
                .NotEmpty().WithMessage("O telefone do funcionário é obrigatório.")
                .MaximumLength(20).WithMessage("O telefone do funcionário não pode exceder 20 caracteres.")
                .Matches(@"^\d{10,11}$|^(\+\d{1,3}\s?)?(\(?\d{2}\)?\s?\d{4,5}-?\d{4})$").WithMessage("O formato do telefone é inválido.");
        }

        private async Task<bool> BeUniqueCpf(string cnpj, CancellationToken cancellationToken)
        {
            var existingEmployee = await _employeeRepository.GetByCpfAsync(cnpj);
            return existingEmployee == null;
        }
    }
}
