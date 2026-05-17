using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using araras_health_hub_api.Common;

using ArarasHealthHub.Application.Features.StockMovements.Queries.GetAllStockMovements;
using ArarasHealthHub.Application.Features.StockMovements.Queries.GetMovementsByDirection;
using ArarasHealthHub.Application.Features.StockMovements.Queries.GetMovementsByReason;
using ArarasHealthHub.Application.Features.StockMovements.Queries.GetStockMovementById;
using ArarasHealthHub.Application.Features.StockMovements.Queries.GetStockMovementsByDocument;
using ArarasHealthHub.Application.Features.StockMovements.Queries.GetStockMovementsByPeriod;
using ArarasHealthHub.Application.Features.StockMovements.Queries.GetStockMovementsByProduct;
using ArarasHealthHub.Application.Features.StockMovements.Responses;
using ArarasHealthHub.Shared.Results;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace araras_health_hub_api.Controllers
{
    [Route("api/v1/stock-movements")]
    [Authorize]
    public class StockMovementsController : BaseApiController
    {
        [HttpGet]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(PagedResult<StockMovementListItemResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll(
            [FromQuery] GetAllStockMovementsQuery query,
            CancellationToken cancellationToken)
        {
            return await Send(query, cancellationToken);
        }

        [HttpGet("{id:int}")]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(Result<StockMovementResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(
            int id,
            CancellationToken cancellationToken)
        {
            return await Send(
                new GetStockMovementByIdQuery(id),
                cancellationToken);
        }

        [HttpGet("by-product/{productId:int}")]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(PagedResult<StockMovementListItemResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByProduct(
            int productId,
            [FromQuery] GetStockMovementsByProductQuery query,
            CancellationToken cancellationToken)
        {
            query.ProductId = productId;

            return await Send(query, cancellationToken);
        }

        [HttpGet("by-period")]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(PagedResult<StockMovementListItemResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByPeriod(
            [FromQuery] GetStockMovementsByPeriodQuery query,
            CancellationToken cancellationToken)
        {
            return await Send(query, cancellationToken);
        }

        [HttpGet("by-document")]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(PagedResult<StockMovementListItemResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByDocument(
            [FromQuery] GetStockMovementsByDocumentQuery query,
            CancellationToken cancellationToken)
        {
            return await Send(query, cancellationToken);
        }

        [HttpGet("by-reason")]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(PagedResult<StockMovementListItemResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByReason(
            [FromQuery] GetMovementsByReasonQuery query,
            CancellationToken cancellationToken)
        {
            return await Send(query, cancellationToken);
        }

        [HttpGet("by-direction")]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(PagedResult<StockMovementListItemResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByDirection(
            [FromQuery] GetMovementsByDirectionQuery query,
            CancellationToken cancellationToken)
        {
            return await Send(query, cancellationToken);
        }
    }
}
