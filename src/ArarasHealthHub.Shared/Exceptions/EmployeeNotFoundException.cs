using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Shared.Exceptions
{
    public sealed class EmployeeNotFoundException : NotFoundException
    {
        public EmployeeNotFoundException(int employeeId)
            : base($"Funcionário com ID {employeeId} não foi encontrado.")
        {
        }
    }
}
