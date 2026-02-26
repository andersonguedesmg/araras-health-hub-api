using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Employees.Commands.DeactivateEmployee
{
    public sealed class DeactivateEmployeeCommandHandler
        : IRequestHandler<DeactivateEmployeeCommand, Result>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public DeactivateEmployeeCommandHandler(
            IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Result> Handle(
            DeactivateEmployeeCommand request,
            CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository
                .GetByIdAsync(request.Id, cancellationToken);

            if (employee is null)
                throw new NotFoundException("Funcionário não foi encontrado.");

            if (!employee.IsActive)
                throw new BusinessRuleException("O funcionário já está inativo.");

            employee.Deactivate();

            await _employeeRepository
                .UpdateAsync(employee, cancellationToken);

            return Result.Success("Funcionário desativado com sucesso.");
        }
    }
}
