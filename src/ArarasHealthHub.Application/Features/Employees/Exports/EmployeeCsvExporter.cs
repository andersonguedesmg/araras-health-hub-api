using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArarasHealthHub.Domain.Entities;

namespace ArarasHealthHub.Application.Features.Employees.Exports
{
    public static class EmployeeCsvExporter
    {
        public static byte[] Export(IEnumerable<Employee> employees)
        {
            var sb = new StringBuilder();

            sb.AppendLine("NOME, CPF, FUNÇÃO, TELEFONE, STATUS");

            foreach (var employee in employees)
            {
                sb.AppendLine(
                    $"{employee.Name}, " +
                    $"{employee.Cpf}, " +
                    $"{employee.Function}, " +
                    $"{employee.Phone}, " +
                    $"{(employee.IsActive ? "Ativo" : "Inativo")}"
                );
            }

            return new UTF8Encoding(true).GetBytes(sb.ToString());
        }
    }
}
