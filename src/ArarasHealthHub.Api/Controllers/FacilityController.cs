using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Facilities.Commands.ChangeStatusFacility;
using ArarasHealthHub.Application.Features.Facilities.Commands.CreateFacility;
using ArarasHealthHub.Application.Features.Facilities.Commands.DeleteFacility;
using ArarasHealthHub.Application.Features.Facilities.Commands.UpdateFacility;
using ArarasHealthHub.Application.Features.Facilities.Dtos;
using ArarasHealthHub.Application.Features.Facilities.Queries.ExportFacilities;
using ArarasHealthHub.Application.Features.Facilities.Queries.GetAllFacilities;
using ArarasHealthHub.Application.Features.Facilities.Queries.GetFacilityById;
using ArarasHealthHub.Application.Features.Facilities.Queries.GetFacilityDropdownOptions;
using ArarasHealthHub.Shared.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArarasHealthHub.Api.Controllers
{
    [Route("api/facility")]
    [ApiController]
    [Authorize]
    public class FacilityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FacilityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getAll")]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(PagedResponse<FacilityDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllFacilitiesQuery query)
        {
            var result = await _mediator.Send(query);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("getById/{id}")]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(ApiResponse<FacilityDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var query = new GetFacilityByIdQuery(id);
            var result = await _mediator.Send(query);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("create")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(ApiResponse<int>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Create([FromBody] CreateFacilityCommand command)
        {
            var result = await _mediator.Send(command);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("update/{id}")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateFacilityCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest(new ApiResponse<bool>(StatusCodes.Status400BadRequest, ApiMessages.IdMismatch, false));
            }
            var result = await _mediator.Send(command);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("delete/{id}")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var command = new DeleteFacilityCommand(id);
            var result = await _mediator.Send(command);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPatch("changeStatus/{id}")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ChangeStatus([FromRoute] int id, [FromBody] ChangeStatusFacilityCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest(new ApiResponse<bool>(StatusCodes.Status400BadRequest, ApiMessages.IdMismatch, false));
            }
            var result = await _mediator.Send(command);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("getDropdownOptions")]
        [ProducesResponseType(typeof(ApiResponse<List<FacilityNameDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDropdownOptions()
        {
            var query = new GetFacilityDropdownOptionsQuery();
            var result = await _mediator.Send(query);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("export")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Export([FromQuery] string? searchTerm)
        {
            var facilityDtos = await _mediator.Send(new ExportFacilitiesQuery { SearchTerm = searchTerm });

            var sb = new StringBuilder();
            sb.AppendLine("ID,NOME,ENDEREÇO,NÚMERO,BAIRRO,CIDADE,ESTADO,CEP,E-MAIL,TELEFONE,STATUS");

            foreach (var facilityDto in facilityDtos)
            {
                sb.Append($"{facilityDto.Id},{facilityDto.Name},{facilityDto.Address},{facilityDto.Number},{facilityDto.Neighborhood},{facilityDto.City},{facilityDto.State},{facilityDto.Cep},{facilityDto.Email},{facilityDto.Phone},{(facilityDto.IsActive ? "Ativo" : "Inativo")}\r\n");
            }

            var fileName = $"unidade_{DateTime.Now:yyyyMMddHHmmss}.csv";

            var utf8WithBom = new UTF8Encoding(true);
            var fileBytes = utf8WithBom.GetBytes(sb.ToString());

            return File(fileBytes, "text/csv", fileName);
        }
    }
}
