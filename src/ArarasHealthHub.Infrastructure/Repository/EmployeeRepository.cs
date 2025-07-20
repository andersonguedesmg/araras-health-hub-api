using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Employee.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Infrastructure.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDBContext _context;

        public EmployeeRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Employee?> ChangeStatusAsync(int id, ChangeStatusEmployeeRequestDto employeeDto)
        {
            var existingEmployee = await _context.Employee.FirstOrDefaultAsync(u => u.Id == id);

            if (existingEmployee == null)
            {
                return null;
            }

            existingEmployee.IsActive = employeeDto.IsActive;
            existingEmployee.UpdatedOn = DateTime.Now;

            await _context.SaveChangesAsync();

            return existingEmployee;
        }

        public async Task<Employee> CreateAsync(Employee employeeModel)
        {
            await _context.Employee.AddAsync(employeeModel);
            await _context.SaveChangesAsync();
            return employeeModel;
        }

        public async Task<Employee?> DeleteAsync(int id)
        {
            var employeeModel = await _context.Employee.FirstOrDefaultAsync(u => u.Id == id);

            if (employeeModel == null)
            {
                return null;
            }

            _context.Employee.Remove(employeeModel);
            await _context.SaveChangesAsync();
            return employeeModel;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Employee.ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _context.Employee.FindAsync(id);
        }

        public async Task<Employee?> UpdateAsync(int id, UpdateEmployeeRequestDto employeeDto)
        {
            var existingEmployee = await _context.Employee.FirstOrDefaultAsync(d => d.Id == id);

            if (existingEmployee == null)
            {
                return null;
            }

            existingEmployee.Name = employeeDto.Name;
            existingEmployee.Cpf = employeeDto.Cpf;
            existingEmployee.Function = employeeDto.Function;
            existingEmployee.Phone = employeeDto.Phone;
            existingEmployee.UpdatedOn = DateTime.Now;

            await _context.SaveChangesAsync();

            return existingEmployee;
        }
    }
}
