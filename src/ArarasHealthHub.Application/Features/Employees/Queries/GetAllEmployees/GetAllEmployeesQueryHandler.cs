using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Employees.Responses;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Results;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Employees.Queries.GetAllEmployees
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, PagedResult<EmployeeListItemResponse>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetAllEmployeesQueryHandler(
            IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<PagedResult<EmployeeListItemResponse>> Handle(
            GetAllEmployeesQuery request,
            CancellationToken cancellationToken)
        {
            var query = _employeeRepository
                .AsQueryable()
                .AsNoTracking();

            if (request.IsActive.HasValue)
            {
                query = query.Where(s => s.IsActive == request.IsActive.Value);
            }

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim();

                query = query.Where(e =>
                    EF.Functions.Like(e.Name, $"%{term}%") ||
                    EF.Functions.Like(e.Cpf, $"%{term}%") ||
                    EF.Functions.Like(e.Function, $"%{term}%") ||
                    EF.Functions.Like(e.Phone, $"%{term}%"));
            }

            var totalCount = await query.CountAsync(cancellationToken);

            query = request.OrderBy?.ToLower() switch
            {
                "name" => request.SortOrder == "desc"
                    ? query.OrderByDescending(e => e.Name)
                    : query.OrderBy(e => e.Name),

                "cpf" => request.SortOrder == "desc"
                    ? query.OrderByDescending(e => e.Cpf)
                    : query.OrderBy(e => e.Cpf),

                "function" => request.SortOrder == "desc"
                    ? query.OrderByDescending(e => e.Function)
                    : query.OrderBy(e => e.Function),

                "phone" => request.SortOrder == "desc"
                    ? query.OrderByDescending(e => e.Phone)
                    : query.OrderBy(e => e.Phone),

                _ => query.OrderBy(e => e.Name)
            };

            var items = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(e => new EmployeeListItemResponse(
                    e.Id,
                    e.Name,
                    e.Cpf,
                    e.Function,
                    e.Phone,
                    e.IsActive))
                .ToListAsync(cancellationToken);

            return PagedResult<EmployeeListItemResponse>.Success(
                items,
                request.PageNumber,
                request.PageSize,
                totalCount,
                "Funcionários listados com sucesso.");
        }
    }
}
