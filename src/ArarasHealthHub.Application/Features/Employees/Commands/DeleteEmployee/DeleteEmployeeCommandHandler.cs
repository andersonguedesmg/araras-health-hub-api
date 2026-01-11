using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, ApiResponse<object>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public DeleteEmployeeCommandHandler(
            IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<ApiResponse<object>> Handle(
            DeleteEmployeeCommand request,
            CancellationToken cancellationToken)
        {
            var existingEmployee =
                await _employeeRepository.GetByIdAsync(request.Id);

            if (existingEmployee is null)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status404NotFound,
                    ApiMessages.NotFound("Funcionário")
                );
            }

            await _employeeRepository.DeleteAsync(existingEmployee);

            return ApiResponse<object>.SuccessResponse(
                StatusCodes.Status200OK,
                ApiMessages.DeletedSuccessfully("Funcionário")
            );
        }
    }
}
