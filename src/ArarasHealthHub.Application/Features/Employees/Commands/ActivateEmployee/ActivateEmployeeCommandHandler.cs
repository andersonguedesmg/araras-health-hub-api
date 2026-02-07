using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;

using MediatR;

using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Employees.Commands.ActivateEmployee
{
    public class ActivateEmployeeCommandHandler : IRequestHandler<ActivateEmployeeCommand, ApiResponse<object>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public ActivateEmployeeCommandHandler(
            IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<ApiResponse<object>> Handle(
            ActivateEmployeeCommand request,
            CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(request.Id, cancellationToken);

            if (employee is null)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status404NotFound,
                    ApiMessages.EntityNotFound(EntityNames.Employee)
                );
            }

            if (employee.IsActive)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status409Conflict,
                    ApiMessages.EntityAlreadyActive(EntityNames.Employee)
                );
            }

            employee.Activate();
            await _employeeRepository.UpdateAsync(employee, cancellationToken);

            return ApiResponse<object>.SuccessResponse(
                StatusCodes.Status200OK,
                ApiMessages.EntityActivated(EntityNames.Employee)
            );
        }
    }
}
