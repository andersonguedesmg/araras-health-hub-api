using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Suppliers.Commands.ChangeStatusSupplier;
using ArarasHealthHub.Application.Features.Suppliers.Commands.CreateSupplier;
using ArarasHealthHub.Application.Features.Suppliers.Commands.DeleteSupplier;
using ArarasHealthHub.Application.Features.Suppliers.Commands.UpdateSupplier;
using ArarasHealthHub.Application.Features.Suppliers.Dtos;
using ArarasHealthHub.Application.Features.Suppliers.Queries.ExportSuppliers;
using ArarasHealthHub.Application.Features.Suppliers.Queries.GetAllSuppliers;
using ArarasHealthHub.Application.Features.Suppliers.Queries.GetSupplierById;
using ArarasHealthHub.Application.Features.Suppliers.Queries.GetSupplierDropdownOptions;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArarasHealthHub.Api.Controllers
{
    [Route("api/supplier")]
    [ApiController]
    [Authorize]
    public class SupplierController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SupplierController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getAll")]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(PagedResponse<SupplierDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllSuppliersQuery query)
        {
            var result = await _mediator.Send(query);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("getById/{id}")]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(ApiResponse<SupplierDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var query = new GetSupplierByIdQuery(id);
            var result = await _mediator.Send(query);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("create")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(ApiResponse<int>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Create([FromBody] CreateSupplierCommand command)
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
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateSupplierCommand command)
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
            var command = new DeleteSupplierCommand(id);
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
        public async Task<IActionResult> ChangeStatus([FromRoute] int id, [FromBody] ChangeStatusSupplierCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest(new ApiResponse<bool>(StatusCodes.Status400BadRequest, ApiMessages.IdMismatch, false));
            }
            var result = await _mediator.Send(command);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("getDropdownOptions")]
        [ProducesResponseType(typeof(ApiResponse<List<SupplierNameDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDropdownOptions()
        {
            var query = new GetSupplierDropdownOptionsQuery();
            var result = await _mediator.Send(query);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("export")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Export([FromQuery] string? searchTerm)
        {
            var supplierDtos = await _mediator.Send(new ExportSuppliersQuery { SearchTerm = searchTerm });
            if (supplierDtos == null || !supplierDtos.Any())
            {
                return NotFound(new ApiResponse<object>(StatusCodes.Status404NotFound, ApiMessages.ExportEmpty("fornecedor(a)"), null!));
            }

            var sb = new StringBuilder();

            sb.AppendLine("RAZÃO SOCIAL, NOME FANTASIA, CNPJ, RUA, NÚMERO, COMPLEMENTO, BAIRRO, CIDADE, ESTADO, CEP, E-MAIL, TELEFONE, STATUS");

            foreach (var supplierDto in supplierDtos)
            {
                sb.Append(
                    $"{supplierDto.LegalName}, " +
                    $"{supplierDto.TradeName}, " +
                    $"{supplierDto.Cnpj}, " +
                    $"{supplierDto.Address.Street}, " +
                    $"{supplierDto.Address.Number}, " +
                    $"{supplierDto.Address.Complement}, " +
                    $"{supplierDto.Address.Neighborhood}, " +
                    $"{supplierDto.Address.City}, " +
                    $"{supplierDto.Address.State}, " +
                    $"{supplierDto.Address.Cep}, " +
                    $"{supplierDto.Contact.Email}, " +
                    $"{supplierDto.Contact.Phone}, " +
                    $"{(supplierDto.IsActive ? "Ativo" : "Inativo")}\r\n"
                );
            }

            var fileName = $"fornecedores_{DateTime.Now:yyyyMMddHHmmss}.csv";

            var utf8WithBom = new UTF8Encoding(true);
            var fileBytes = utf8WithBom.GetBytes(sb.ToString());

            return File(fileBytes, "text/csv", fileName);
        }
    }
}
