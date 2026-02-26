using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Features.Employees.Responses
{
    public record EmployeeListItemResponse(
        int Id,
        string Name,
        string Cpf,
        string Function,
        string Phone,
        bool IsActive
    );
}
