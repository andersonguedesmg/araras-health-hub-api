using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Core;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Application.Features.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, ApiResponse<int>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<int>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var existingEmployee = await _employeeRepository.GetByCpfAsync(request.Cpf);
            if (existingEmployee != null)
            {
                return new ApiResponse<int>(StatusCodes.Status409Conflict, ApiMessages.CpfAlreadyExists, 0);
            }

            var employee = _mapper.Map<Employee>(request);

            await _employeeRepository.AddAsync(employee);

            return new ApiResponse<int>(StatusCodes.Status201Created, ApiMessages.CreatedSuccessfully("Funcionário"), employee.Id);
        }
    }
}
