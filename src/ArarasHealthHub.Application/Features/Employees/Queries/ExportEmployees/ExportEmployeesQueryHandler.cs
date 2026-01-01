using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Employees.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Employees.Queries.ExportEmployees
{
    public class ExportEmployeesQueryHandler : IRequestHandler<ExportEmployeesQuery, IEnumerable<EmployeeDto>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public ExportEmployeesQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeDto>> Handle(ExportEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employeesQuery = _employeeRepository.GetQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var searchTermLower = request.SearchTerm.ToLower();
                employeesQuery = employeesQuery.Where(e =>
                    e.Name.ToLower().Contains(searchTermLower) ||
                    e.Cpf.ToLower().Contains(searchTermLower) ||
                    e.Function.ToLower().Contains(searchTermLower) ||
                    e.Phone.ToLower().Contains(searchTermLower)
                );
            }

            var allFilteredEmployees = await employeesQuery.OrderBy(e => e.Name).ToListAsync(cancellationToken);
            var employeeDtos = _mapper.Map<IEnumerable<EmployeeDto>>(allFilteredEmployees);

            return employeeDtos;
        }
    }
}
