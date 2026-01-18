using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Employees.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core.Pagination;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Employees.Queries.GetEmployeeDropdown
{
    public class GetEmployeeDropdownQueryHandler : IRequestHandler<GetEmployeeDropdownQuery, PagedResponse<EmployeeNameDto>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeDropdownQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<PagedResponse<EmployeeNameDto>> Handle(
            GetEmployeeDropdownQuery request,
            CancellationToken cancellationToken)
        {
            var queryable = _employeeRepository
                .GetQueryable()
                .Where(e => e.IsActive);

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim().ToLower();
                queryable = queryable.Where(e => e.Name.ToLower().Contains(term));
            }

            var totalCount = await queryable.CountAsync(cancellationToken);

            queryable = queryable
                .OrderBy(e => e.Name)
                .ApplyPagination(request.PageNumber, request.PageSize);

            var items = await queryable
                .Select(e => new EmployeeNameDto
                {
                    Id = e.Id,
                    Name = e.Name
                })
                .ToListAsync(cancellationToken);

            return PagedResponse<EmployeeNameDto>.SuccessPaged(
                request.PageNumber,
                request.PageSize,
                totalCount,
                items
            );
        }
    }
}
