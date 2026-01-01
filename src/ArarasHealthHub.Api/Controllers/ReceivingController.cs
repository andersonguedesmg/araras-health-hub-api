using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using ArarasHealthHub.Shared.Core;
using ArarasHealthHub.Application.Features.Receivings.Commands.CreateReceiving;
using ArarasHealthHub.Application.Features.Receivings.Dtos;
using ArarasHealthHub.Application.Features.Receivings.Queries.GetReceivingById;
using ArarasHealthHub.Application.Features.Receivings.Queries.GetAllReceivings;
using ArarasHealthHub.Application.Features.Receivings.Queries.ExportReceivings;
using System.Text;
using System.Globalization;

namespace ArarasHealthHub.Api.Controllers
{
    [Route("api/receiving")]
    [ApiController]
    [Authorize]
    public class ReceivingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReceivingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(ApiResponse<int>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Create(CreateReceivingCommand command)
        {
            var result = await _mediator.Send(command);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("getById/{id}")]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(ApiResponse<ReceivingDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var query = new GetReceivingByIdQuery(id);
            var result = await _mediator.Send(query);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("getAll")]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(PagedResponse<ReceivingDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllReceivingsQuery query)
        {
            var result = await _mediator.Send(query);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("export")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Export([FromQuery] string? searchTerm)
        {
            var detailDtos = await _mediator.Send(new ExportReceivingsQuery { SearchTerm = searchTerm });
            if (detailDtos == null || !detailDtos.Any())
            {
                return NotFound(new ApiResponse<object>(StatusCodes.Status404NotFound, ApiMessages.ExportEmpty("recebimento"), null!));
            }

            var sb = new StringBuilder();

            sb.AppendLine("ID, NF, AF, DATA, FORNECEDOR (RAZÃO SOCIAL), FORNECEDOR (NOME FANTASIA), RESPONSÁVEL, OBSERVAÇÃO" +
                          "PRODUTO, LOTE, MARCA, VALIDADE, QUANTIDADE, VALOR UNITÁRIO, VALOR TOTAL");

            var culture = CultureInfo.InvariantCulture;

            foreach (var detail in detailDtos)
            {
                sb.Append(
                    $"{detail.ReceivingId}, " +
                    $"{detail.InvoiceNumber}, " +
                    $"{detail.SupplyAuthorization}, " +
                    $"{detail.ReceivingDate:dd/MM/yyyy HH:mm:ss}, " +
                    $"{detail.SupplierLegalName}, " +
                    $"{detail.SupplierTradeName}, " +
                    $"{detail.ResponsibleName}, " +
                    $"{detail.Observation}, " +
                    $"{detail.ProductName}, " +
                    $"{detail.Batch}, " +
                    $"{detail.Brand}, " +
                    $"{detail.ExpiryDate:dd/MM/yyyy}, " +
                    $"{detail.QuantityReceived.ToString("F3", culture)}, " +
                    $"{detail.UnitValue.ToString("F2", culture)}, " +
                    $"{detail.ItemTotalValue.ToString("F2", culture)}" +
                    "\r\n"
                );
            }

            var fileName = $"recebimento_detalhado_{DateTime.Now:yyyyMMddHHmmss}.csv";
            var utf8WithBom = new UTF8Encoding(true);
            var fileBytes = utf8WithBom.GetBytes(sb.ToString());

            return File(fileBytes, "text/csv", fileName);
        }
    }
}
