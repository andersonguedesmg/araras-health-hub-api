using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using araras_health_hub_api.Common;

using ArarasHealthHub.Application.Features.Receivings.Commands.CreateReceiving;
using ArarasHealthHub.Application.Features.Receivings.Queries.GetAllReceivings;
using ArarasHealthHub.Application.Features.Receivings.Queries.GetReceivingById;
using ArarasHealthHub.Application.Features.Receivings.Queries.GetReceivingsByPeriod;
using ArarasHealthHub.Application.Features.Receivings.Queries.GetReceivingsByProduct;
using ArarasHealthHub.Application.Features.Receivings.Queries.GetReceivingsBySupplier;
using ArarasHealthHub.Application.Features.Receivings.Responses;
using ArarasHealthHub.Shared.Results;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArarasHealthHub.Api.Controllers
{
    [Route("api/v1/receivings")]
    [Authorize]
    public class ReceivingsController : BaseApiController
    {
        [HttpPost]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Create(
            [FromBody] CreateReceivingCommand command,
            CancellationToken cancellationToken)
        {
            return await SendCreated(
                command,
                nameof(GetById),
                id => new { id },
                cancellationToken);
        }

        [HttpGet("{id:int}")]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(Result<ReceivingResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(
            int id,
            CancellationToken cancellationToken)
        {
            return await Send(
                new GetReceivingByIdQuery(id),
                cancellationToken);
        }

        [HttpGet]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(PagedResult<ReceivingListItemResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll(
            [FromQuery] GetAllReceivingsQuery query,
            CancellationToken cancellationToken)
        {
            return await Send(query, cancellationToken);
        }

        [HttpGet("supplier/{supplierId:int}")]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(PagedResult<ReceivingListItemResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetBySupplier(
            int supplierId,
            [FromQuery] GetReceivingsBySupplierQuery query,
            CancellationToken cancellationToken)
        {
            query.SupplierId = supplierId;

            return await Send(query, cancellationToken);
        }

        [HttpGet("period")]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(PagedResult<ReceivingListItemResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByPeriod(
            [FromQuery] GetReceivingsByPeriodQuery query,
            CancellationToken cancellationToken)
        {
            return await Send(query, cancellationToken);
        }

        [HttpGet("product/{productId:int}")]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(PagedResult<ReceivingListItemResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByProduct(
            int productId,
            [FromQuery] GetReceivingsByProductQuery query,
            CancellationToken cancellationToken)
        {
            query.ProductId = productId;

            return await Send(query, cancellationToken);
        }
    }
}
