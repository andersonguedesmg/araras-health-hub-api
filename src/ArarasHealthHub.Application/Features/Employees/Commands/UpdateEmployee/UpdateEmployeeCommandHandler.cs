using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using AutoMapper;

using MediatR;

namespace ArarasHealthHub.Application.Features.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Result>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public UpdateEmployeeCommandHandler(
            IEmployeeRepository employeeRepository,
            IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<Result> Handle(
            UpdateEmployeeCommand request,
            CancellationToken cancellationToken)
        {
            var existingEmployee =
                await _employeeRepository.GetByIdAsync(
                    request.Id,
                    cancellationToken);

            if (existingEmployee is null)
                throw new NotFoundException("Funcionário não foi encontrado.");

            var duplicateCpfEmployee =
                await _employeeRepository.GetByCpfAsync(
                    request.Cpf,
                    cancellationToken);

            if (duplicateCpfEmployee is not null &&
                duplicateCpfEmployee.Id != request.Id)
                throw new BusinessRuleException(
                    "Já existe um funcionário com o CPF informado.");

            _mapper.Map(request, existingEmployee);
            existingEmployee.SetUpdatedOn();

            await _employeeRepository.UpdateAsync(
                existingEmployee,
                cancellationToken);

            return Result.Success("Funcionário atualizado com sucesso.");
        }
    }
}
