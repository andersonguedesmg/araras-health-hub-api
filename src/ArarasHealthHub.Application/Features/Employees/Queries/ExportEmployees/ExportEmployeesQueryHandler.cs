using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Employees.Exports;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Employees.Queries.ExportEmployees
{
    public class ExportEmployeesQueryHandler : IRequestHandler<ExportEmployeesQuery, ApiResponse<FileResponse>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public ExportEmployeesQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<ApiResponse<FileResponse>> Handle(
            ExportEmployeesQuery request,
            CancellationToken cancellationToken)
        {
            var query = _employeeRepository.GetQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim().ToLower();

                query = query.Where(e =>
                    e.Name.ToLower().Contains(term) ||
                    e.Cpf.ToLower().Contains(term) ||
                    e.Function.ToLower().Contains(term) ||
                    e.Phone.ToLower().Contains(term)
                );
            }

            var employees = await query
                .OrderBy(e => e.Name)
                .ToListAsync(cancellationToken);

            if (!employees.Any())
            {
                return new ApiResponse<FileResponse>(
                    StatusCodes.Status404NotFound,
                    ApiMessages.ExportEmpty("funcionário"),
                    false
                );
            }

            var csvBytes = EmployeeCsvExporter.Export(employees);

            return new ApiResponse<FileResponse>(
                StatusCodes.Status200OK,
                ApiMessages.OperationSuccessful,
                new FileResponse
                {
                    Content = csvBytes,
                    ContentType = "text/csv",
                    FileName = $"funcionarios_{DateTime.UtcNow:yyyyMMddHHmmss}.csv"
                }
            );
        }
    }
}
