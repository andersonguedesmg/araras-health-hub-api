using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Employees.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Employees.Queries.GetAllEmployees
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, PagedResponse<EmployeeDto>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public GetAllEmployeesQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<EmployeeDto>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employeesQuery = _employeeRepository.GetQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var searchTermLower = request.SearchTerm.ToLower();
                employeesQuery = employeesQuery.Where(p =>
                    p.Name.ToLower().Contains(searchTermLower) ||
                    p.Cpf.ToLower().Contains(searchTermLower) ||
                    p.Function.ToLower().Contains(searchTermLower) ||
                    p.Phone.ToLower().Contains(searchTermLower)
                );
            }

            var totalCount = await employeesQuery.CountAsync(cancellationToken);

            IQueryable<Employee> orderedEmployees;
            switch (request.OrderBy.ToLower())
            {
                case "name":
                    orderedEmployees = request.SortOrder.ToLower() == "desc" ?
                        employeesQuery.OrderByDescending(s => s.Name) :
                        employeesQuery.OrderBy(s => s.Name);
                    break;
                case "cpf":
                    orderedEmployees = request.SortOrder.ToLower() == "desc" ?
                        employeesQuery.OrderByDescending(s => s.Cpf) :
                        employeesQuery.OrderBy(s => s.Cpf);
                    break;
                default:
                    orderedEmployees = request.SortOrder.ToLower() == "desc" ?
                        employeesQuery.OrderByDescending(s => s.Id) :
                        employeesQuery.OrderBy(s => s.Id);
                    break;
            }

            var pagedEmployees = await orderedEmployees
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            var employeeDtos = _mapper.Map<List<EmployeeDto>>(pagedEmployees);

            return new PagedResponse<EmployeeDto>(
                request.PageNumber,
                request.PageSize,
                totalCount,
                employeeDtos
            );
        }
    }
}
