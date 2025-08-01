using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Stocks.Commands.UpdateMinQuantity;
using ArarasHealthHub.Application.Features.Stocks.Dtos;
using ArarasHealthHub.Application.Features.Stocks.Queries.GetLowStockAlerts;
using ArarasHealthHub.Application.Features.Stocks.Queries.GetStockByProductId;
using ArarasHealthHub.Application.Features.Stocks.Queries.GetStockOverview;
using ArarasHealthHub.Shared.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArarasHealthHub.Api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    // [Authorize]
    public class StockController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StockController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getAll")]
        [ProducesResponseType(typeof(PagedResponse<StockOverviewDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll([FromQuery] GetStockOverviewQuery query)
        {
            var result = await _mediator.Send(query);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("getById/{productId}")]
        [ProducesResponseType(typeof(ApiResponse<StockDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByProductId(int productId)
        {
            var query = new GetStockByProductIdQuery(productId);
            var result = await _mediator.Send(query);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("low-stock")]
        [ProducesResponseType(typeof(ApiResponse<List<StockDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetLowStockAlerts()
        {
            var query = new GetLowStockAlertsQuery();
            var result = await _mediator.Send(query);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPatch("{productId}/min-quantity")]
        [ProducesResponseType(typeof(ApiResponse<StockDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateMinQuantity(int productId, [FromBody] UpdateMinQuantityRequest request)
        {
            var command = new UpdateMinQuantityCommand(productId, request.NewMinQuantity);
            var result = await _mediator.Send(command);
            return StatusCode(result.StatusCode, result);
        }
    }
}
