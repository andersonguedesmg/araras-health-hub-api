using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Employees.Responses;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Employees.Queries.GetEmployeeById
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, Result<EmployeeResponse>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeByIdQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Result<EmployeeResponse>> Handle(
            GetEmployeeByIdQuery request,
            CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(request.Id, cancellationToken);

            if (employee is null)
                throw new NotFoundException("Funcionário não foi encontrado.");

            var response = new EmployeeResponse(
                employee.Id,
                employee.Name,
                employee.Cpf,
                employee.Function,
                employee.Phone,
                employee.CreatedOn,
                employee.UpdatedOn,
                employee.IsActive
            );

            return Result<EmployeeResponse>.Success(
                response,
                "Funcionário encontrado com sucesso.");
        }
    }
}
