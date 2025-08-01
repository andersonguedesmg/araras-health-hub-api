using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.StockMovements.Commands.CreateStockEntry;
using ArarasHealthHub.Application.Features.StockMovements.Commands.CreateStockExit;
using ArarasHealthHub.Application.Features.StockMovements.Dtos;
using ArarasHealthHub.Application.Features.StockMovements.Queries.GetAllStockMovements;
using ArarasHealthHub.Application.Features.StockMovements.Queries.GetStockMovementById;
using ArarasHealthHub.Shared.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace araras_health_hub_api.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/stock-movement")]
    [ApiController]
    // [Authorize]
    public class StockMovementController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StockMovementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("entry")]
        [ProducesResponseType(typeof(ApiResponse<StockMovementDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateEntry([FromBody] CreateStockEntryDto request)
        {
            var command = new CreateStockEntryCommand(
                request.ProductId,
                request.Quantity,
                request.SourceDocumentId,
                request.SourceDocumentType,
                request.ResponsibleId
            );
            var result = await _mediator.Send(command);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("exit")]
        [ProducesResponseType(typeof(ApiResponse<StockMovementDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateExit([FromBody] CreateStockExitDto request)
        {
            var command = new CreateStockExitCommand(
                request.ProductId,
                request.Quantity,
                request.SourceDocumentId,
                request.SourceDocumentType,
                request.ResponsibleId
            );
            var result = await _mediator.Send(command);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("getById/{id}")]
        [ProducesResponseType(typeof(ApiResponse<StockMovementDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetStockMovementByIdQuery(id);
            var result = await _mediator.Send(query);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("getAll")]
        [ProducesResponseType(typeof(PagedResponse<StockMovementDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllStockMovementsQuery query)
        {
            var result = await _mediator.Send(query);
            return StatusCode(result.StatusCode, result);
        }
    }
}
