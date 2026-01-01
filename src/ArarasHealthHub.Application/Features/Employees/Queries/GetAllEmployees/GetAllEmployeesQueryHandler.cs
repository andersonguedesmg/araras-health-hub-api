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
                var searchTerm = request.SearchTerm.Trim().ToLower();

                employeesQuery = employeesQuery.Where(e =>
                    e.Name.ToLower().Contains(searchTerm) ||
                    e.Cpf.ToLower().Contains(searchTerm) ||
                    e.Function.ToLower().Contains(searchTerm) ||
                    e.Phone.ToLower().Contains(searchTerm)
                );
            }

            var totalCount = await employeesQuery.CountAsync(cancellationToken);

            IOrderedQueryable<Employee> orderedQuery;
            switch (request.OrderBy?.ToLower())
            {
                case "name":
                    orderedQuery = request.SortOrder?.ToLower() == "desc"
                        ? employeesQuery.OrderByDescending(p => p.Name)
                        : employeesQuery.OrderBy(p => p.Name);
                    break;
                case "cpf":
                    orderedQuery = request.SortOrder?.ToLower() == "desc" ?
                        employeesQuery.OrderByDescending(e => e.Cpf) :
                        employeesQuery.OrderBy(e => e.Cpf);
                    break;
                case "function":
                    orderedQuery = request.SortOrder?.ToLower() == "desc" ?
                        employeesQuery.OrderByDescending(e => e.Function) :
                        employeesQuery.OrderBy(e => e.Function);
                    break;
                default:
                    orderedQuery = employeesQuery.OrderBy(e => e.Name);
                    break;
            }

            var pagedEmployees = await orderedQuery
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
