using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Employees.Commands.ChangeStatusEmployee
{
    public class ChangeStatusEmployeeCommandHandler : IRequestHandler<ChangeStatusEmployeeCommand, ApiResponse<bool>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public ChangeStatusEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<ApiResponse<bool>> Handle(ChangeStatusEmployeeCommand command, CancellationToken cancellationToken)
        {
            var existingEmployee = await _employeeRepository.GetByIdAsync(command.Id);

            if (existingEmployee == null)
            {
                return new ApiResponse<bool>(StatusCodes.Status404NotFound, ApiMessages.NotFound("Funcionário"), false);
            }

            if (command.IsActive)
            {
                existingEmployee.Activate();
            }
            else
            {
                existingEmployee.Deactivate();
            }

            await _employeeRepository.UpdateAsync(existingEmployee);

            var message = command.IsActive ? ApiMessages.ActivatedSuccessfully("Funcionário") : ApiMessages.DeactivatedSuccessfully("Funcionário");
            return new ApiResponse<bool>(StatusCodes.Status200OK, message, true);
        }
    }
}
