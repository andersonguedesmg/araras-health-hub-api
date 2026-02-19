using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Common.Helpers;
using ArarasHealthHub.Application.Features.Employees.Commands.UpdateEmployee;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Messages;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.Employees.Validation
{
    public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public UpdateEmployeeCommandValidator(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;

            RuleFor(x => x.Id)
                .GreaterThan(0)
                    .WithMessage(ValidationMessages.InvalidId);

            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithName("Nome")
                    .WithMessage(ValidationMessages.RequiredField)
                .MaximumLength(100)
                    .WithMessage(ValidationMessages.MaxLengthField(100));

            RuleFor(x => x.Cpf)
                .NotEmpty()
                    .WithName("CPF")
                    .WithMessage(ValidationMessages.RequiredField)
                .Matches(@"^\d{3}\.\d{3}\.\d{3}\-\d{2}$")
                    .WithMessage(ValidationMessages.InvalidCpfFormat)
                .Must(CpfValidatorHelper.IsValidCpf)
                    .WithMessage(ValidationMessages.InvalidField)
                .MustAsync(BeUniqueCpf)
                    .WithMessage(ApiMessages.CpfAlreadyExists);

            RuleFor(x => x.Function)
                .NotEmpty()
                    .WithName("Função")
                    .WithMessage(ValidationMessages.RequiredField)
                .MaximumLength(100)
                    .WithMessage(ValidationMessages.MaxLengthField(100));

            RuleFor(x => x.Phone)
                .NotEmpty()
                    .WithName("Telefone")
                    .WithMessage(ValidationMessages.RequiredField)
                .MaximumLength(20)
                    .WithMessage(ValidationMessages.MaxLengthField(20))
                .Matches(@"^\d{10,11}$|^(\+\d{1,3}\s?)?(\(?\d{2}\)?\s?\d{4,5}-?\d{4})$")
                    .WithMessage(ValidationMessages.InvalidPhoneFormat);
        }

        private async Task<bool> BeUniqueCpf(
            UpdateEmployeeCommand command,
            string cpf,
            CancellationToken cancellationToken)
        {
            var existingEmployee = await _employeeRepository.GetByCpfAsync(cpf, cancellationToken);
            return existingEmployee is null || existingEmployee.Id == command.Id;
        }
    }
}
