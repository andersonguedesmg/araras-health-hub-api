using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using AutoMapper;

using MediatR;
namespace ArarasHealthHub.Application.Features.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Result<int>>
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

        public async Task<Result<int>> Handle(
            CreateEmployeeCommand request,
            CancellationToken cancellationToken)
        {
            var existingEmployee =
                await _employeeRepository.GetByCpfAsync(
                    request.Cpf,
                    cancellationToken);

            if (existingEmployee is not null)
                throw new BusinessRuleException("Já existe um funcionário com o CPF informado.");

            var employee = _mapper.Map<Employee>(request);

            await _employeeRepository.AddAsync(employee, cancellationToken);

            return Result<int>.Success(
                employee.Id,
                "Funcionário criado com sucesso.");
        }
    }
}
