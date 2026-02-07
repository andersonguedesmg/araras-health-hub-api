using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core.Dtos;
using ArarasHealthHub.Shared.Core.Pagination;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Employees.Queries.GetEmployeeDropdown
{
    public class GetEmployeeDropdownQueryHandler : IRequestHandler<GetEmployeeDropdownQuery, PagedResponse<DropdownItemDto>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeDropdownQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<PagedResponse<DropdownItemDto>> Handle(
            GetEmployeeDropdownQuery request,
            CancellationToken cancellationToken)
        {
            var queryable = _employeeRepository
                .AsQueryable()
                .Where(e => e.IsActive);

            var term = request.SearchTerm?.Trim();

            if (!string.IsNullOrWhiteSpace(term))
            {
                var search = term.ToLower();

                queryable = queryable.Where(e =>
                    e.Name.ToLower().Contains(search)
                );
            }

            var totalCount = await queryable.CountAsync(cancellationToken);

            var items = await queryable
                .OrderBy(x => x.Name)
                .ApplyPagination(request.PageNumber, request.PageSize)
                .Select(x => new DropdownItemDto
                {
                    Id = x.Id,
                    Label = x.Name
                })
                .ToListAsync(cancellationToken);

            return PagedResponse<DropdownItemDto>.SuccessPaged(
                request.PageNumber,
                request.PageSize,
                totalCount,
                items
            );
        }
    }
}
