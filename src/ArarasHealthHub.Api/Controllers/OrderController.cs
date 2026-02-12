using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Orders.Commands.ApproveOrder;
using ArarasHealthHub.Application.Features.Orders.Commands.CancelOrder;
using ArarasHealthHub.Application.Features.Orders.Commands.CreateDispenseReturn;
using ArarasHealthHub.Application.Features.Orders.Commands.CreateOrder;
using ArarasHealthHub.Application.Features.Orders.Commands.FinalizeOrder;
using ArarasHealthHub.Application.Features.Orders.Commands.SeparateOrder;
using ArarasHealthHub.Application.Features.Orders.Dtos;
using ArarasHealthHub.Application.Features.Orders.Queries.ExportOrders;
using ArarasHealthHub.Application.Features.Orders.Queries.GetAllOrders;
using ArarasHealthHub.Application.Features.Orders.Queries.GetOrderById;
using ArarasHealthHub.Application.Features.Orders.Queries.GetOrderPickingDetails;
using ArarasHealthHub.Application.Interfaces.Services;
using ArarasHealthHub.Shared.Core;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArarasHealthHub.Api.Controllers
{
    [Route("api/order")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IPdfService _pdfService;

        public OrderController(IMediator mediator, IPdfService pdfService)
        {
            _mediator = mediator;
            _pdfService = pdfService;
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(ApiResponse<int>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Create([FromBody] CreateOrderCommand command)
        {
            var result = await _mediator.Send(command);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("getById/{id}")]
        [ProducesResponseType(typeof(ApiResponse<OrderDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var query = new GetOrderByIdQuery(id);
            var result = await _mediator.Send(query);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("getAll")]
        [ProducesResponseType(typeof(PagedResponseO<OrderDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllOrdersQuery query)
        {
            var result = await _mediator.Send(query);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("picking-details/{id}")]
        [ProducesResponseType(typeof(ApiResponse<OrderDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<OrderDto>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<OrderDto>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetPickingDetails(int id)
        {
            var query = new GetOrderPickingDetailsQuery { Id = id };
            var result = await _mediator.Send(query);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("approve")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(ApiResponse<OrderDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Approve([FromBody] ApproveOrderCommand command)
        {
            var result = await _mediator.Send(command);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("separate")]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(ApiResponse<OrderDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Separate([FromBody] SeparateOrderCommand command)
        {
            var result = await _mediator.Send(command);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("finalize")]
        [ProducesResponseType(typeof(ApiResponse<OrderDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Finalize([FromBody] FinalizeOrderCommand command)
        {
            var result = await _mediator.Send(command);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("cancel")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Cancel([FromBody] CancelOrderCommand command)
        {
            var result = await _mediator.Send(command);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("return")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Return([FromBody] CreateDispenseReturnCommand command)
        {
            var result = await _mediator.Send(command);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("picking-report/{id}")]
        [Authorize(Policy = "CanManageResource")]
        public async Task<IActionResult> GetPickingReport(int id)
        {
            var result = await _mediator.Send(new GetOrderPickingDetailsQuery { Id = id });

            if (!result.Success || result.Data == null)
            {
                return StatusCode(result.StatusCode, result);
            }

            byte[] pdfBytes = await _pdfService.GeneratePickingListAsync(result.Data);

            var fileName = $"Lista_Separacao_Pedido_{id}.pdf";
            return File(pdfBytes, "application/pdf", fileName);
        }

        [HttpGet("export")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Export([FromQuery] int? orderStatusId, [FromQuery] string? searchTerm)
        {
            var orders = await _mediator.Send(new ExportOrdersQuery
            {
                OrderStatusId = orderStatusId,
                SearchTerm = searchTerm
            });

            if (orders == null || !orders.Any())
            {
                return NotFound(new ApiResponseO<object>(StatusCodes.Status404NotFound, ApiMessages.ExportEmpty("pedido"), null!));
            }

            var sb = new StringBuilder();

            sb.AppendLine("ID, DATA, UNIDADE, SOLICITANTE, QTD ITENS, STATUS, MOTIVO CANCELAMENTO");

            foreach (var order in orders)
            {
                sb.AppendLine(
                    $"{order.Id}, " +
                    $"{order.CreatedAt:dd/MM/yyyy HH:mm}, " +
                    $"{order.OrderFacility!.Label}, " +
                    $"{order.CreatedByEmployee!.Label}, " +
                    $"{order.OrderItems.Count}, " +
                    $"{order.OrderStatus!.Description}, "
                );
            }

            var fileName = $"pedidos_{DateTime.Now:yyyyMMddHHmmss}.csv";

            var utf8WithBom = new UTF8Encoding(true);
            var fileBytes = utf8WithBom.GetBytes(sb.ToString());

            return File(fileBytes, "text/csv", fileName);
        }
    }
}
