using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Features.Employees.Responses
{
    public record EmployeeResponse(
        int Id,
        string Name,
        string Cpf,
        string Function,
        string Phone,
        DateTime CreatedOn,
        DateTime? UpdatedOn,
        bool IsActive
    );
}
