using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Shared.Responses;

using MediatR;

namespace ArarasHealthHub.Application.Features.Employees.Queries.ExportEmployees
{
    public class ExportEmployeesQuery : IRequest<ApiResponse<FileResponse>>
    {
        public string? SearchTerm { get; set; }
    }
}
