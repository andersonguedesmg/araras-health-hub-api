using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Orders.Commands.ApproveOrder;
using ArarasHealthHub.Application.Features.Orders.Commands.CreateOrder;
using ArarasHealthHub.Application.Features.Orders.Commands.FinalizeOrder;
using ArarasHealthHub.Application.Features.Orders.Commands.SeparateOrder;
using ArarasHealthHub.Application.Features.Orders.Dtos;
using ArarasHealthHub.Application.Features.Orders.Queries.GetAllOrders;
using ArarasHealthHub.Application.Features.Orders.Queries.GetOrderById;
using ArarasHealthHub.Shared.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArarasHealthHub.Api.Controllers
{
    [Route("api/order")]
    [ApiController]
    // [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(ApiResponse<int>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateOrderDto orderDto)
        {
            var command = new CreateOrderCommand(
                orderDto.Observation,
                orderDto.CreatedByEmployeeId,
                orderDto.CreatedByAccountId,
                orderDto.OrderItems
            );

            var result = await _mediator.Send(command);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("getById/{id}")]
        [ProducesResponseType(typeof(ApiResponse<OrderDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var query = new GetOrderByIdQuery(id);
            var result = await _mediator.Send(query);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("getAll")]
        [ProducesResponseType(typeof(PagedResponse<OrderDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllOrdersQuery query)
        {
            var result = await _mediator.Send(query);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("approve")]
        [ProducesResponseType(typeof(ApiResponse<OrderDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Approve([FromBody] ApproveOrderDto orderDto)
        {
            var command = new ApproveOrderCommand(
                orderDto.OrderId,
                orderDto.ApprovedByEmployeeId,
                orderDto.ApprovedByAccountId,
                orderDto.OrderItems
            );

            var result = await _mediator.Send(command);

            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("separate")]
        [ProducesResponseType(typeof(ApiResponse<OrderDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Separate([FromBody] SeparateOrderDto orderDto)
        {
            var command = new SeparateOrderCommand(
                orderDto.OrderId,
                orderDto.SeparatedByEmployeeId,
                orderDto.SeparatedByAccountId,
                orderDto.OrderItems
            );

            var result = await _mediator.Send(command);

            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("finalize")]
        [ProducesResponseType(typeof(ApiResponse<OrderDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Finalize([FromBody] FinalizeOrderDto orderDto)
        {
            var command = new FinalizeOrderCommand(
                orderDto.OrderId,
                orderDto.FinalizedByEmployeeId,
                orderDto.FinalizedByAccountId
            );

            var result = await _mediator.Send(command);

            return StatusCode(result.StatusCode, result);
        }
    }
}
