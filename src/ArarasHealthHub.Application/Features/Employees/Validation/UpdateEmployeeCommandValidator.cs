using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Common.Helpers;
using ArarasHealthHub.Application.Features.Employees.Commands.UpdateEmployee;

using FluentValidation;

namespace ArarasHealthHub.Application.Features.Employees.Validation
{
    public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
    {
        public UpdateEmployeeCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Identificador inválido.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Nome é obrigatório.")
                .MaximumLength(100).WithMessage("Nome não pode exceder 100 caracteres.");

            RuleFor(x => x.Cpf)
                .NotEmpty().WithMessage("CPF é obrigatório.")
                .Matches(@"^\d{3}\.\d{3}\.\d{3}\-\d{2}$")
                .WithMessage("CPF deve estar no formato XXX.XXX.XXX-XX.")
                .Must(CpfValidatorHelper.IsValidCpf)
                .WithMessage("CPF inválido.");

            RuleFor(x => x.Function)
                .NotEmpty().WithMessage("Função é obrigatória.")
                .MaximumLength(100).WithMessage("Função não pode exceder 100 caracteres.");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Telefone é obrigatório.")
                .MaximumLength(20).WithMessage("Telefone não pode exceder 20 caracteres.")
                .Matches(@"^\d{10,11}$|^(\+\d{1,3}\s?)?(\(?\d{2}\)?\s?\d{4,5}-?\d{4})$")
                .WithMessage("Telefone inválido.");
        }
    }
}
