using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using araras_health_hub_api.Common;

using ArarasHealthHub.Application.Features.Orders.Commands.ApproveOrder;
using ArarasHealthHub.Application.Features.Orders.Commands.CancelOrder;
using ArarasHealthHub.Application.Features.Orders.Commands.CreateOrder;
using ArarasHealthHub.Application.Features.Orders.Commands.FinalizeOrder;
using ArarasHealthHub.Application.Features.Orders.Commands.ReturnOrder;
using ArarasHealthHub.Application.Features.Orders.Commands.SeparateOrder;
using ArarasHealthHub.Application.Features.Orders.Queries.GetAllOrders;
using ArarasHealthHub.Application.Features.Orders.Queries.GetOrderById;
using ArarasHealthHub.Application.Features.Orders.Queries.GetOrderPickingDetails;
using ArarasHealthHub.Application.Features.Orders.Responses;
using ArarasHealthHub.Shared.Results;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArarasHealthHub.Api.Controllers
{
    [Route("api/v1/orders")]
    [Authorize]
    public class OrdersController : BaseApiController
    {
        [HttpPost]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(
            [FromBody] CreateOrderCommand command,
            CancellationToken cancellationToken)
        {
            return await SendCreated(
                command,
                nameof(GetById),
                id => new { id },
                cancellationToken);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Result<OrderResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(
            int id,
            CancellationToken cancellationToken)
        {
            return await Send(new GetOrderByIdQuery(id), cancellationToken);
        }

        [HttpGet]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(PagedResult<OrderListItemResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll(
            [FromQuery] GetAllOrdersQuery query,
            CancellationToken cancellationToken)
        {
            return await Send(query, cancellationToken);
        }

        [HttpPost("{id:int}/approve")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Approve(
            int id,
            [FromBody] ApproveOrderCommand command,
            CancellationToken cancellationToken)
        {
            command = command with { OrderId = id };

            return await Send(command, cancellationToken);
        }

        [HttpPost("{id:int}/separate")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Separate(
            int id,
            [FromBody] SeparateOrderCommand command,
            CancellationToken cancellationToken)
        {
            command = command with { OrderId = id };

            return await Send(command, cancellationToken);
        }

        [HttpPost("{id:int}/finalize")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Finalize(
            int id,
            [FromBody] FinalizeOrderCommand command,
            CancellationToken cancellationToken)
        {
            command = command with { OrderId = id };

            return await Send(command, cancellationToken);
        }

        [HttpPost("{id:int}/cancel")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Cancel(
            int id,
            [FromBody] CancelOrderCommand command,
            CancellationToken cancellationToken)
        {
            command = command with { OrderId = id };

            return await Send(command, cancellationToken);
        }

        [HttpPost("{id:int}/return")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Return(
            int id,
            [FromBody] CreateReturnOrderCommand command,
            CancellationToken cancellationToken)
        {
            command = command with { OriginalOrderId = id };

            return await Send(command, cancellationToken);
        }

        [HttpGet("{id:int}/picking")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(Result<OrderPickingResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPickingDetails(
            int id,
            CancellationToken cancellationToken)
        {
            return await Send(
                new GetOrderPickingDetailsQuery(id),
                cancellationToken);
        }
    }
}
