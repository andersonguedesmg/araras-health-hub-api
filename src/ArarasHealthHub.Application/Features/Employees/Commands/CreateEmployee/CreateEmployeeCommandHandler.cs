using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Messages;
using ArarasHealthHub.Shared.Responses;

using AutoMapper;

using MediatR;

using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, ApiResponse<int>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public CreateEmployeeCommandHandler(
            IEmployeeRepository employeeRepository,
            IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<int>> Handle(
            CreateEmployeeCommand request,
            CancellationToken cancellationToken)
        {
            var existingEmployee =
                await _employeeRepository.GetByCpfAsync(request.Cpf, cancellationToken);

            if (existingEmployee is not null)
            {
                return ApiResponse<int>.FailureResponse(
                    StatusCodes.Status409Conflict,
                    ApiMessages.CpfAlreadyExists
                );
            }

            var employee = _mapper.Map<Employee>(request);

            await _employeeRepository.AddAsync(employee, cancellationToken);

            return ApiResponse<int>.SuccessResponse(
                StatusCodes.Status201Created,
                ApiMessages.EntityCreated(EntityNames.Employee),
                employee.Id
            );
        }
    }
}
