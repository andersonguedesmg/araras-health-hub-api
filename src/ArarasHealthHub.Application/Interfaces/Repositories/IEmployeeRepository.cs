using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Employee.Dtos;
using ArarasHealthHub.Domain.Entities;

namespace ArarasHealthHub.Application.Interfaces.Repositories
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
