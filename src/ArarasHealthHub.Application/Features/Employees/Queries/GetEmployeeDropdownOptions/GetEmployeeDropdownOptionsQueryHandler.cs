using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Employees.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;
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
            var query = _employeeRepository.GetQueryable();
            query = query
                .Where(s => s.IsActive)
                .OrderBy(s => s.Name);

            var dropdownOptions = await query
                .Select(s => new EmployeeNameDto
                {
                    Id = s.Id,
                    Name = s.Name
                })
                .ToListAsync(cancellationToken);

            return new ApiResponse<List<EmployeeNameDto>>(
                StatusCodes.Status200OK,
                ApiMessages.OperationSuccessful,
                dropdownOptions
            );
        }
    }
}
