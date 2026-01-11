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
            var employee = await _employeeRepository.GetByIdAsync(request.Id);

            if (employee is null)
            {
                return new ApiResponse<EmployeeDto>(
                    StatusCodes.Status404NotFound,
                    ApiMessages.NotFound("Funcionário"),
                    null!);
            }

            var employeeDto = _mapper.Map<EmployeeDto>(employee);

            return new ApiResponse<EmployeeDto>(
                StatusCodes.Status200OK,
                ApiMessages.FoundSuccessfully("Funcionário"),
                employeeDto);
        }
    }
}
