using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Employees.Commands.ChangeStatusEmployee
{
    public class ChangeStatusEmployeeCommandHandler : IRequestHandler<ChangeStatusEmployeeCommand, ApiResponse<object>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public ChangeStatusEmployeeCommandHandler(
            IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<ApiResponse<object>> Handle(
            ChangeStatusEmployeeCommand command,
            CancellationToken cancellationToken)
        {
            var existingEmployee =
                await _employeeRepository.GetByIdAsync(command.Id);

            if (existingEmployee is null)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status404NotFound,
                    ApiMessages.NotFound("Funcionário")
                );
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

            var message = command.IsActive
                ? ApiMessages.ActivatedSuccessfully("Funcionário")
                : ApiMessages.DeactivatedSuccessfully("Funcionário");

            return ApiResponse<object>.SuccessResponse(
                StatusCodes.Status200OK,
                message
            );
        }
    }
}
