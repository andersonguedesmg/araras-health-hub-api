using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Responses;
using ArarasHealthHub.Shared.Results;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Employees.Queries.GetEmployeeDropdown
{
    public class GetEmployeeDropdownQueryHandler : IRequestHandler<GetEmployeeDropdownQuery, PagedResult<DropdownItemResponse>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeDropdownQueryHandler(
            IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<PagedResult<DropdownItemResponse>> Handle(
            GetEmployeeDropdownQuery request,
            CancellationToken cancellationToken)
        {
            var query = _employeeRepository
                .AsQueryable()
                .AsNoTracking()
                .Where(e => e.IsActive);

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim();

                query = query.Where(e =>
                    EF.Functions.Like(e.Name, $"%{term}%"));
            }

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderBy(e => e.Name)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(e => new DropdownItemResponse(
                    e.Id,
                    e.Name))
                .ToListAsync(cancellationToken);

            return PagedResult<DropdownItemResponse>.Success(
                items,
                request.PageNumber,
                request.PageSize,
                totalCount,
                "Funcionários listados para seleção.");
        }
    }
}
