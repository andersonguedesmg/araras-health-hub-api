using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Stocks.Commands.CreateStockAdjustment;
using ArarasHealthHub.Application.Features.Stocks.Commands.UpdateMinQuantity;
using ArarasHealthHub.Application.Features.Stocks.Dtos;
using ArarasHealthHub.Application.Features.Stocks.Queries.ExportCriticalStockOverview;
using ArarasHealthHub.Application.Features.Stocks.Queries.ExportStockGeneralOverview;
using ArarasHealthHub.Application.Features.Stocks.Queries.GetAllStockAdjustments;
using ArarasHealthHub.Application.Features.Stocks.Queries.GetAllStockMinQuantities;
using ArarasHealthHub.Application.Features.Stocks.Queries.GetCriticalStockOverview;
using ArarasHealthHub.Application.Features.Stocks.Queries.GetStockAdjustment;
using ArarasHealthHub.Application.Features.Stocks.Queries.GetStockByProductId;
using ArarasHealthHub.Application.Features.Stocks.Queries.GetStockGeneralOverview;
using ArarasHealthHub.Shared.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArarasHealthHub.Api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    [Authorize]
    public class StockController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StockController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("general")]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(PagedResponse<StockOverviewDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetGeneralStockOverview([FromQuery] GetStockGeneralOverviewQuery query)
        {
            var result = await _mediator.Send(query);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("getById/{productId}")]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(ApiResponse<StockDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByProductId(int productId)
        {
            var query = new GetStockByProductIdQuery(productId);
            var result = await _mediator.Send(query);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("critical")]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(ApiResponse<List<StockDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetCriticalStockOverview([FromQuery] GetCriticalStockOverviewQuery query)
        {
            var result = await _mediator.Send(query);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPatch("{productId}/min-quantity")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(ApiResponse<StockDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateMinQuantity(int productId, [FromBody] UpdateMinQuantityRequest request)
        {
            var command = new UpdateMinQuantityCommand(productId, request.NewMinQuantity);
            var result = await _mediator.Send(command);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("create-adjustment")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateAdjustment([FromBody] CreateStockAdjustmentCommand command)
        {
            var result = await _mediator.Send(command);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("adjustment/{id}")]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(ApiResponse<StockAdjustmentDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetStockAdjustmentById(int id)
        {
            var query = new GetStockAdjustmentByIdQuery(id);
            var result = await _mediator.Send(query);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("adjustments")]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(PagedResponse<StockAdjustmentDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetAllStockAdjustments([FromQuery] GetAllStockAdjustmentsQuery query)
        {
            var result = await _mediator.Send(query);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("min-quantities")]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(PagedResponse<StockMinQuantityDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetAllMinQuantities([FromQuery] GetAllStockMinQuantitiesQuery query)
        {
            var result = await _mediator.Send(query);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("export")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Export([FromQuery] string? searchTerm)
        {
            var stockDtos = await _mediator.Send(new ExportStockGeneralOverviewQuery { SearchTerm = searchTerm });

            var sb = new StringBuilder();
            var culture = CultureInfo.InvariantCulture;

            sb.AppendLine("ID_PRODUTO,PRODUTO,CATEGORIA_PRINCIPAL,SUBCATEGORIA,APRESENTACAO," +
                          "QTD_ATUAL,QTD_RESERVADA,QTD_DISPONIVEL,QTD_MINIMA,CUSTO_MEDIO_UNITARIO," +
                          "STATUS_CRITICO,DATA_CRIACAO,DATA_ATUALIZACAO");

            foreach (var stock in stockDtos)
            {
                sb.Append(
                    $"{stock.ProductId}," +
                    $"{stock.ProductName.Replace(",", "")}," +
                    $"{stock.MainCategory}," +
                    $"{stock.SubCategory}," +
                    $"{stock.PresentationForm}," +
                    $"{stock.CurrentQuantity.ToString("F3", culture)}," +
                    $"{stock.ReservedQuantity.ToString("F3", culture)}," +
                    $"{stock.AvailableQuantity.ToString("F3", culture)}," +
                    $"{stock.MinQuantity.ToString("F3", culture)}," +
                    $"{stock.AverageCost.ToString("F4", culture)}," +
                    $"{stock.CriticalStatus}," +
                    $"{stock.CreatedOn:dd/MM/yyyy HH:mm:ss}," +
                    $"{stock.UpdatedOn?.ToString("dd/MM/yyyy HH:mm:ss")}" +
                    "\r\n"
                );
            }

            var fileName = $"estoque_geral_{DateTime.Now:yyyyMMddHHmmss}.csv";
            var utf8WithBom = new UTF8Encoding(true);
            var fileBytes = utf8WithBom.GetBytes(sb.ToString());

            return File(fileBytes, "text/csv", fileName);
        }

        [HttpGet("export-critical")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> ExportCritical([FromQuery] string? searchTerm)
        {
            var stockDtos = await _mediator.Send(new ExportCriticalStockOverviewQuery { SearchTerm = searchTerm });

            var sb = new StringBuilder();
            var culture = CultureInfo.InvariantCulture;

            sb.AppendLine("ID_PRODUTO,PRODUTO,CATEGORIA_PRINCIPAL,SUBCATEGORIA,APRESENTACAO," +
                          "QTD_ATUAL,QTD_RESERVADA,QTD_DISPONIVEL,QTD_MINIMA,CUSTO_MEDIO_UNITARIO," +
                          "STATUS_CRITICO,DATA_CRIACAO,DATA_ATUALIZACAO");

            foreach (var stock in stockDtos)
            {
                sb.Append(
                    $"{stock.ProductId}," +
                    $"{stock.ProductName.Replace(",", "")}," +
                    $"{stock.MainCategory}," +
                    $"{stock.SubCategory}," +
                    $"{stock.PresentationForm}," +
                    $"{stock.CurrentQuantity.ToString("F3", culture)}," +
                    $"{stock.ReservedQuantity.ToString("F3", culture)}," +
                    $"{stock.AvailableQuantity.ToString("F3", culture)}," +
                    $"{stock.MinQuantity.ToString("F3", culture)}," +
                    $"{stock.AverageCost.ToString("F4", culture)}," +
                    $"{stock.CriticalStatus}," +
                    $"{stock.CreatedOn:dd/MM/yyyy HH:mm:ss}," +
                    $"{stock.UpdatedOn?.ToString("dd/MM/yyyy HH:mm:ss")}" +
                    "\r\n"
                );
            }

            var fileName = $"estoque_critico_{DateTime.Now:yyyyMMddHHmmss}.csv";
            var utf8WithBom = new UTF8Encoding(true);
            var fileBytes = utf8WithBom.GetBytes(sb.ToString());

            return File(fileBytes, "text/csv", fileName);
        }
    }
}
