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
            var allEmployees = await _employeeRepository.GetAllAsync();

            var totalCount = allEmployees.Count();

            IOrderedEnumerable<Employee> orderedEmployees;
            switch (request.OrderBy.ToLower())
            {
                case "name":
                    orderedEmployees = request.SortOrder.ToLower() == "desc" ?
                        allEmployees.OrderByDescending(s => s.Name) :
                        allEmployees.OrderBy(s => s.Name);
                    break;
                case "cpf":
                    orderedEmployees = request.SortOrder.ToLower() == "desc" ?
                        allEmployees.OrderByDescending(s => s.Cpf) :
                        allEmployees.OrderBy(s => s.Cpf);
                    break;
                default:
                    orderedEmployees = request.SortOrder.ToLower() == "desc" ?
                        allEmployees.OrderByDescending(s => s.Id) :
                        allEmployees.OrderBy(s => s.Id);
                    break;
            }

            var pagedEmployees = orderedEmployees
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();

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
