using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Employees.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Employees.Queries.GetEmployeeDropdownOptions
{
    public class GetEmployeeDropdownOptionsQueryHandler : IRequestHandler<GetEmployeeDropdownOptionsQuery, ApiResponse<List<EmployeeNameDto>>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public GetEmployeeDropdownOptionsQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<EmployeeNameDto>>> Handle(GetEmployeeDropdownOptionsQuery request, CancellationToken cancellationToken)
        {
            var query = _employeeRepository.AsQueryable();

            query = query.Where(s => s.IsActive);

            query = query.OrderBy(s => s.Name);

            var activeEmployees = await query.ToListAsync(cancellationToken);

            var dropdownOptions = _mapper.Map<List<EmployeeNameDto>>(activeEmployees);

            return new ApiResponse<List<EmployeeNameDto>>(
                StatusCodes.Status200OK,
                ApiMessages.MsgOperationSuccessful,
                dropdownOptions
            );
        }
    }
}
