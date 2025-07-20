using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Employee.Dtos;
using ArarasHealthHub.Domain.Entities;

namespace ArarasHealthHub.Application.Features.Employee.Mappers
{
    public static class EmployeeMappers
    {
        public static EmployeeDto ToEmployeeDto(this EmployeeDto employeeModel)
        {
            return new EmployeeDto
            {
                Id = employeeModel.Id,
                Name = employeeModel.Name,
                Cpf = employeeModel.Cpf,
                Function = employeeModel.Function,
                Phone = employeeModel.Phone,
                CreatedOn = employeeModel.CreatedOn,
                UpdatedOn = employeeModel.UpdatedOn,
                IsActive = employeeModel.IsActive,
            };
        }

        public static Employee ToEmployeeFromCreateDto(this CreateEmployeeRequestDto employeeModelDto)
        {
            return new Employee
            {
                Name = employeeModelDto.Name,
                Cpf = employeeModelDto.Cpf,
                Function = employeeModelDto.Function,
                Phone = employeeModelDto.Phone,
                CreatedOn = employeeModelDto.CreatedOn,
                IsActive = employeeModelDto.IsActive,
            };
        }
    }
}
