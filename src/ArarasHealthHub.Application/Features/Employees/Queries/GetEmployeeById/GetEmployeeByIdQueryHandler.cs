using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Employees.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;

using AutoMapper;

using MediatR;

using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Employees.Queries.GetEmployeeById
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, ApiResponse<EmployeeDto>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public GetEmployeeByIdQueryHandler(
            IEmployeeRepository employeeRepository,
            IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<EmployeeDto>> Handle(
            GetEmployeeByIdQuery request,
            CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(request.Id, cancellationToken);

            if (employee is null)
            {
                return ApiResponse<EmployeeDto>.FailureResponse(
                    StatusCodes.Status404NotFound,
                    ApiMessages.EntityNotFound(EntityNames.Employee)
                );
            }

            var employeeDto = _mapper.Map<EmployeeDto>(employee);

            return ApiResponse<EmployeeDto>.SuccessResponse(
                StatusCodes.Status200OK,
                ApiMessages.OperationSuccessful,
                employeeDto
            );
        }
    }
}
