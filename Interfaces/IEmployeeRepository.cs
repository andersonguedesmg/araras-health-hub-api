using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using araras_health_hub_api.Dtos.Employee;
using araras_health_hub_api.Models;

namespace araras_health_hub_api.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllAsync();
        Task<Employee?> GetByIdAsync(int id);
        Task<Employee> CreateAsync(Employee employeeModel);
        Task<Employee?> UpdateAsync(int id, UpdateEmployeeRequestDto employeeDto);
        Task<Employee?> ChangeStatusAsync(int id, ChangeStatusEmployeeRequestDto employeeDto);
        Task<Employee?> DeleteAsync(int id);
    }
}
