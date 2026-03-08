using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Result>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public UpdateEmployeeCommandHandler(
            IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Result> Handle(
            UpdateEmployeeCommand request,
            CancellationToken cancellationToken)
        {
            var existingEmployee =
                await _employeeRepository.GetByIdAsync(
                    request.Id,
                    cancellationToken);

            if (existingEmployee is null)
                throw new NotFoundException("Funcionário não foi encontrado.");

            var duplicateCpfEmployee =
                await _employeeRepository.GetByCpfAsync(
                    request.Cpf,
                    cancellationToken);

            if (duplicateCpfEmployee is not null &&
                duplicateCpfEmployee.Id != request.Id)
                throw new BusinessRuleException(
                    "Já existe um funcionário com o CPF informado.");

            existingEmployee.Update(
                request.Name,
                request.Function,
                request.Phone);

            await _employeeRepository.UpdateAsync(
                existingEmployee,
                cancellationToken);

            return Result.Success("Funcionário atualizado com sucesso.");
        }
    }
}
