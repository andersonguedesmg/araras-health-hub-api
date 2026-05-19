using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using araras_health_hub_api.Common;

using ArarasHealthHub.Application.Features.Stocks.Commands.CreateStockAdjustment;
using ArarasHealthHub.Application.Features.Stocks.Commands.SetMinimumStockLevel;
using ArarasHealthHub.Application.Features.Stocks.Queries.GetAllMinimumStockLevels;
using ArarasHealthHub.Application.Features.Stocks.Queries.GetAllStockAdjustments;
using ArarasHealthHub.Application.Features.Stocks.Queries.GetAvailableStockLots;
using ArarasHealthHub.Application.Features.Stocks.Queries.GetCriticalStocks;
using ArarasHealthHub.Application.Features.Stocks.Queries.GetStockAdjustmentById;
using ArarasHealthHub.Application.Features.Stocks.Queries.GetStockByProductId;
using ArarasHealthHub.Application.Features.Stocks.Queries.GetStockLotsNearExpiry;
using ArarasHealthHub.Application.Features.Stocks.Queries.GetStocks;
using ArarasHealthHub.Application.Features.Stocks.Responses;
using ArarasHealthHub.Shared.Results;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArarasHealthHub.Api.Controllers
{
    [Route("api/v1/stocks")]
    [Authorize]
    public class StocksController : BaseApiController
    {
        [HttpPost("adjustments")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CreateAdjustment(
            CreateStockAdjustmentCommand command,
            CancellationToken cancellationToken)
        {
            return await SendCreated(
                command,
                nameof(GetStockAdjustmentById),
                id => new { id },
                cancellationToken);
        }

        [HttpGet("adjustments")]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(PagedResult<StockAdjustmentListItemResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllStockAdjustments(
            [FromQuery] GetAllStockAdjustmentsQuery query,
            CancellationToken cancellationToken)
        {
            return await Send(query, cancellationToken);
        }

        [HttpGet("adjustments/{id:int}")]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(Result<StockAdjustmentResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetStockAdjustmentById(
            int id,
            CancellationToken cancellationToken)
        {
            return await Send(
                new GetStockAdjustmentByIdQuery(id),
                cancellationToken);
        }

        [HttpPatch("minimum-stock-level")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SetMinimumStockLevel(
            SetMinimumStockLevelCommand command,
            CancellationToken cancellationToken)
        {
            return await Send(command, cancellationToken);
        }

        [HttpGet("minimum-stock-levels")]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(PagedResult<MinimumStockLevelListItemResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllMinimumStockLevels(
            [FromQuery] GetAllMinimumStockLevelsQuery query,
            CancellationToken cancellationToken)
        {
            return await Send(query, cancellationToken);
        }

        [HttpGet]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(PagedResult<StockListItemResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll(
            [FromQuery] GetStocksQuery query,
            CancellationToken cancellationToken)
        {
            return await Send(query, cancellationToken);
        }

        [HttpGet("product/{productId:int}")]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(Result<StockResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByProductId(
            int productId,
            CancellationToken cancellationToken)
        {
            return await Send(
                new GetStockByProductIdQuery(productId),
                cancellationToken);
        }

        [HttpGet("critical")]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(PagedResult<StockListItemResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetCriticalStocks(
            [FromQuery] GetCriticalStocksQuery query,
            CancellationToken cancellationToken)
        {
            return await Send(query, cancellationToken);
        }

        [HttpGet("available-lots")]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(PagedResult<StockLotListItemResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAvailableStockLots(
            [FromQuery] GetAvailableStockLotsQuery query,
            CancellationToken cancellationToken)
        {
            return await Send(query, cancellationToken);
        }

        [HttpGet("lots-near-expiry")]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(PagedResult<StockLotNearExpiryListItemResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetStockLotsNearExpiry(
            [FromQuery] GetStockLotsNearExpiryQuery query,
            CancellationToken cancellationToken)
        {
            return await Send(query, cancellationToken);
        }
    }
}
