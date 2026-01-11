using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.StockMovements.Dtos;
using ArarasHealthHub.Application.Features.StockMovements.Queries.GetAllStockMovements;
using ArarasHealthHub.Application.Features.StockMovements.Queries.GetStockMovementById;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace araras_health_hub_api.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/stock-movement")]
    [ApiController]
    [Authorize(Policy = "CanReadManagementResource")]
    public class StockMovementController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StockMovementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getById/{id}")]
        [ProducesResponseType(typeof(ApiResponse<StockMovementDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetStockMovementByIdQuery(id);
            var result = await _mediator.Send(query);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("getAll")]
        [ProducesResponseType(typeof(PagedResponse<StockMovementDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllStockMovementsQuery query)
        {
            var result = await _mediator.Send(query);
            return StatusCode(result.StatusCode, result);
        }
    }
}
