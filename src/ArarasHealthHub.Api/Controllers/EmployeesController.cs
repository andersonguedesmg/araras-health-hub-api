using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using araras_health_hub_api.Common;

using ArarasHealthHub.Application.Features.Employees.Commands.ActivateEmployee;
using ArarasHealthHub.Application.Features.Employees.Commands.CreateEmployee;
using ArarasHealthHub.Application.Features.Employees.Commands.DeactivateEmployee;
using ArarasHealthHub.Application.Features.Employees.Commands.UpdateEmployee;
using ArarasHealthHub.Application.Features.Employees.Dtos;
using ArarasHealthHub.Application.Features.Employees.Queries.ExportEmployees;
using ArarasHealthHub.Application.Features.Employees.Queries.GetAllEmployees;
using ArarasHealthHub.Application.Features.Employees.Queries.GetEmployeeById;
using ArarasHealthHub.Application.Features.Employees.Queries.GetEmployeeDropdown;
using ArarasHealthHub.Shared.Core.Dtos;
using ArarasHealthHub.Shared.Core.Pagination;
using ArarasHealthHub.Shared.Core.Responses;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace ArarasHealthHub.Api.Controllers
{
    [Route("api/v1/employees")]
    [Authorize]
    public class EmployeesController : BaseApiController
    {
        [HttpGet]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(PagedResponse<EmployeeDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllEmployeesQuery query)
        {
            return await Send(query);
        }

        [HttpGet("{id:int}")]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(ApiResponse<EmployeeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            return await Send(new GetEmployeeByIdQuery(0).WithId(id));
        }

        [HttpPost]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(ApiResponse<int>), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateEmployeeCommand command)
        {
            return await Send(command);
        }

        [HttpPut("{id:int}")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, UpdateEmployeeCommand command)
        {
            return await Send(command.WithId(id));
        }

        [HttpPatch("{id:int}/activate")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Activate(int id, ActivateEmployeeCommand command)
        {
            return await Send(command.WithId(id));
        }

        [HttpPatch("{id:int}/deactivate")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Deactivate(int id, DeactivateEmployeeCommand command)
        {
            return await Send(command.WithId(id));
        }

        [HttpGet("dropdown")]
        [ProducesResponseType(typeof(PagedResponse<DropdownItemDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDropdown([FromQuery] GetEmployeeDropdownQuery query)
        {
            return await Send(query);
        }

        [HttpGet("export")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> Export([FromQuery] ExportEmployeesQuery query)
        {
            var response = await Mediator.Send(query);

            if (!response.Success || response.Data == null)
                return StatusCode(response.StatusCode, response);

            return File(
                response.Data.Content,
                response.Data.ContentType,
                response.Data.FileName
            );
        }
    }
}
