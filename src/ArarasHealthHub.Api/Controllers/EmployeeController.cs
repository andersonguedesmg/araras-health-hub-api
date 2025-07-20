using ArarasHealthHub.Application.Features.Employee.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Application.Features.Employee.Mappers;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArarasHealthHub.Api.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepo;

        public EmployeeController(IEmployeeRepository employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        [HttpGet]
        [Route("getAll")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<List<Employee>>(StatusCodes.Status400BadRequest, ApiMessages.Msg400BadRequestError, null!));

            var employees = await _employeeRepo.GetAllAsync();

            if (employees.Count == 0)
            {
                return NotFound(new ApiResponse<Employee>(StatusCodes.Status404NotFound, ApiMessages.MsgNotEmployeesFound, null!));
            }

            return Ok(new ApiResponse<List<Employee>>(StatusCodes.Status200OK, ApiMessages.MsgEmployeesFoundSuccessfully, employees));
        }

        [HttpGet]
        [Route("getById/{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<List<Employee>>(StatusCodes.Status400BadRequest, ApiMessages.Msg400BadRequestError, null!));

            var employee = await _employeeRepo.GetByIdAsync(id);

            if (employee == null)
            {
                return NotFound(new ApiResponse<Employee>(StatusCodes.Status404NotFound, ApiMessages.MsgEmployeeNotFound, null!));
            }

            return Ok(new ApiResponse<Employee>(StatusCodes.Status200OK, ApiMessages.MsgEmployeeFoundSuccessfully, employee));
        }

        [HttpPost]
        [Route("create")]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeRequestDto employeeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<List<Employee>>(StatusCodes.Status400BadRequest, ApiMessages.Msg400BadRequestError, null!));

            var employeeModel = employeeDto.ToEmployeeFromCreateDto();
            var newEmployee = await _employeeRepo.CreateAsync(employeeModel);

            return CreatedAtAction(nameof(GetById), new { id = employeeModel.Id }, new ApiResponse<Employee>(StatusCodes.Status201Created, ApiMessages.MsgEmployeeCreatedSuccessfully, newEmployee));
        }

        [HttpPut]
        [Route("update/{id:int}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateEmployeeRequestDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<List<Employee>>(StatusCodes.Status400BadRequest, ApiMessages.Msg400BadRequestError, null!));

            var employeeModel = await _employeeRepo.UpdateAsync(id, updateDto);

            if (employeeModel == null)
            {
                return NotFound(new ApiResponse<Employee>(StatusCodes.Status404NotFound, ApiMessages.MsgEmployeeNotFound, null!));

            }

            return Ok(new ApiResponse<Employee>(StatusCodes.Status200OK, ApiMessages.MsgEmployeeUpdatedSuccessfully, employeeModel));
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<List<Employee>>(StatusCodes.Status400BadRequest, ApiMessages.Msg400BadRequestError, null!));

            var employeeModel = await _employeeRepo.DeleteAsync(id);

            if (employeeModel == null)
            {
                return NotFound(new ApiResponse<Employee>(StatusCodes.Status404NotFound, ApiMessages.MsgEmployeeNotFound, null!));
            }

            return Ok(new ApiResponse<Employee>(StatusCodes.Status200OK, ApiMessages.MsgEmployeeDeletedSuccessfully, employeeModel));
        }

        [HttpPatch]
        [Route("changeStatus/{id:int}")]
        [Authorize]
        public async Task<IActionResult> ChangeStatus([FromRoute] int id, [FromBody] ChangeStatusEmployeeRequestDto changeStatusDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<List<Employee>>(StatusCodes.Status400BadRequest, ApiMessages.Msg400BadRequestError, null!));

            var employeeModel = await _employeeRepo.ChangeStatusAsync(id, changeStatusDto);

            if (employeeModel == null)
            {
                return NotFound(new ApiResponse<Employee>(StatusCodes.Status404NotFound, ApiMessages.MsgEmployeeNotFound, null!));
            }

            if (changeStatusDto.IsActive == true)
            {
                return Ok(new ApiResponse<Employee>(StatusCodes.Status200OK, ApiMessages.MsgEmployeeActivatedSuccessfully, employeeModel));
            }

            return Ok(new ApiResponse<Employee>(StatusCodes.Status200OK, ApiMessages.MsgEmployeeDisabledSuccessfully, employeeModel));
        }

        [HttpGet]
        [Route("getDropdownOptions")]
        [Authorize]
        public async Task<IActionResult> getDropdownOptions()
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<List<EmployeeNameDto>>(StatusCodes.Status400BadRequest, ApiMessages.Msg400BadRequestError, null!));

            var employees = await _employeeRepo.GetAllAsync();

            if (employees.Count == 0)
            {
                return NotFound(new ApiResponse<EmployeeNameDto>(StatusCodes.Status404NotFound, ApiMessages.MsgNotEmployeesFound, null!));
            }

            var employeeNames = employees.Select(d => new EmployeeNameDto
            {
                Id = d.Id,
                Name = d.Name
            }).ToList();

            return Ok(new ApiResponse<List<EmployeeNameDto>>(StatusCodes.Status200OK, ApiMessages.MsgEmployeesFoundSuccessfully, employeeNames));
        }
    }
}
