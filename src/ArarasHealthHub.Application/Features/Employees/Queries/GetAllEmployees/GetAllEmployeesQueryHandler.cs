using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Employees.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Core.Pagination;

using AutoMapper;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Employees.Queries.GetAllEmployees
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, PagedResponse<EmployeeDto>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public GetAllEmployeesQueryHandler(
            IEmployeeRepository employeeRepository,
            IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<EmployeeDto>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var queryable = _employeeRepository.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim().ToLower();
                queryable = queryable.Where(e =>
                    e.Name.ToLower().Contains(term) ||
                    e.Cpf.ToLower().Contains(term) ||
                    e.Function.ToLower().Contains(term) ||
                    e.Phone.ToLower().Contains(term)
                );
            }

            var totalCount = await queryable.CountAsync(cancellationToken);

            var orderingColumns = new Dictionary<string, Expression<Func<Employee, object>>>
            {
                ["name"] = e => e.Name,
                ["cpf"] = e => e.Cpf,
                ["function"] = e => e.Function,
                ["phone"] = e => e.Phone
            };

            queryable = queryable.ApplyOrdering(
                request.OrderBy?.ToLower(),
                request.SortOrder?.ToLower() ?? "asc",
                orderingColumns
            );

            queryable = queryable.ApplyPagination(
                request.PageNumber,
                request.PageSize
            );

            var items = await queryable.ToListAsync(cancellationToken);

            var dtoList = _mapper.Map<IReadOnlyList<EmployeeDto>>(items);

            return PagedResponse<EmployeeDto>.SuccessPaged(
                request.PageNumber,
                request.PageSize,
                totalCount,
                dtoList
            );
        }
    }
}
