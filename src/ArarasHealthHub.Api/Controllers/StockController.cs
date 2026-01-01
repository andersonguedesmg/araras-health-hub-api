using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Stocks.Commands.CreateStockAdjustment;
using ArarasHealthHub.Application.Features.Stocks.Commands.UpdateMinQuantity;
using ArarasHealthHub.Application.Features.Stocks.Dtos;
using ArarasHealthHub.Application.Features.Stocks.Queries.ExportActiveStockLots;
using ArarasHealthHub.Application.Features.Stocks.Queries.ExportCriticalStockOverview;
using ArarasHealthHub.Application.Features.Stocks.Queries.ExportNearExpiryLots;
using ArarasHealthHub.Application.Features.Stocks.Queries.ExportStockAdjustments;
using ArarasHealthHub.Application.Features.Stocks.Queries.ExportStockGeneralOverview;
using ArarasHealthHub.Application.Features.Stocks.Queries.GetActiveStockLots;
using ArarasHealthHub.Application.Features.Stocks.Queries.GetAllStockAdjustments;
using ArarasHealthHub.Application.Features.Stocks.Queries.GetAllStockMinQuantities;
using ArarasHealthHub.Application.Features.Stocks.Queries.GetCriticalStockOverview;
using ArarasHealthHub.Application.Features.Stocks.Queries.GetNearExpiryLots;
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

        [HttpGet("near-expiry")]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(ApiResponse<List<StockLotNearExpiryDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetNearExpiryLots([FromQuery] GetNearExpiryLotsQuery query)
        {
            var result = await _mediator.Send(query);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("active-lots")]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(ApiResponse<List<StockLotNearExpiryDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetActiveLots([FromQuery] GetActiveStockLotsQuery query)
        {
            var result = await _mediator.Send(query);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("export-general")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> ExportGeneral([FromQuery] string? searchTerm)
        {
            var stockDtos = await _mediator.Send(new ExportStockGeneralOverviewQuery { SearchTerm = searchTerm });
            if (stockDtos == null || !stockDtos.Any())
            {
                return NotFound(new ApiResponse<object>(StatusCodes.Status404NotFound, ApiMessages.ExportEmpty("Estoque Geral"), null!));
            }

            var sb = new StringBuilder();
            var culture = new CultureInfo("pt-BR");

            sb.AppendLine($"PRODUTO, CATEGORIA_PRINCIPAL, SUBCATEGORIA, APRESENTACAO, " +
                          $"QTD_ATUAL, QTD_RESERVADA, QTD_DISPONIVEL, QTD_MINIMA, CUSTO_MEDIO_UNITARIO, " +
                          $"STATUS_CRITICO, DATA_CRIACAO, DATA_ATUALIZACAO");

            foreach (var stock in stockDtos)
            {
                sb.Append($"{stock.ProductName}, ");
                sb.Append($"{stock.MainCategory}, ");
                sb.Append($"{stock.SubCategory}, ");
                sb.Append($"{stock.PresentationForm}, ");
                sb.Append($"{stock.CurrentQuantity.ToString("F3", culture)}, ");
                sb.Append($"{stock.ReservedQuantity.ToString("F3", culture)}, ");
                sb.Append($"{stock.AvailableQuantity.ToString("F3", culture)}, ");
                sb.Append($"{stock.MinQuantity.ToString("F3", culture)}, ");
                sb.Append($"{stock.AverageCost.ToString("C4", culture).Replace("R$", "").Trim()}, ");
                sb.Append($"{stock.CriticalStatus}, ");
                sb.Append($"{stock.CreatedOn:dd/MM/yyyy HH:mm:ss}, ");
                sb.Append($"{stock.UpdatedOn?.ToString("dd/MM/yyyy HH:mm:ss")}");
                sb.Append("\r\n");
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
            if (stockDtos == null || !stockDtos.Any())
            {
                return NotFound(new ApiResponse<object>(StatusCodes.Status404NotFound, ApiMessages.ExportEmpty("Estoque Crítico"), null!));
            }

            var sb = new StringBuilder();
            var culture = CultureInfo.InvariantCulture;

            sb.AppendLine("PRODUTO, CATEGORIA_PRINCIPAL, SUBCATEGORIA, APRESENTACAO, " +
                          "QTD_ATUAL, QTD_RESERVADA, QTD_DISPONIVEL, QTD_MINIMA, CUSTO_MEDIO_UNITARIO, " +
                          "STATUS_CRITICO, DATA_CRIACAO, DATA_ATUALIZACAO");

            foreach (var stock in stockDtos)
            {
                sb.Append(
                    $"{stock.ProductName}, " +
                    $"{stock.MainCategory}, " +
                    $"{stock.SubCategory}, " +
                    $"{stock.PresentationForm}, " +
                    $"{stock.CurrentQuantity.ToString("F3", culture)}, " +
                    $"{stock.ReservedQuantity.ToString("F3", culture)}, " +
                    $"{stock.AvailableQuantity.ToString("F3", culture)}, " +
                    $"{stock.MinQuantity.ToString("F3", culture)}, " +
                    $"{stock.AverageCost.ToString("C4", culture).Replace("R$", "").Trim()}, " +
                    $"{stock.CriticalStatus}, " +
                    $"{stock.CreatedOn:dd/MM/yyyy HH:mm:ss}, " +
                    $"{stock.UpdatedOn?.ToString("dd/MM/yyyy HH:mm:ss")}" +
                    "\r\n"
                );
            }

            var fileName = $"estoque_critico_{DateTime.Now:yyyyMMddHHmmss}.csv";
            var utf8WithBom = new UTF8Encoding(true);
            var fileBytes = utf8WithBom.GetBytes(sb.ToString());

            return File(fileBytes, "text/csv", fileName);
        }

        [HttpGet("export-near-expiry")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> ExportNearExpiryLots([FromQuery] string? searchTerm)
        {
            var lotDtos = await _mediator.Send(new ExportNearExpiryLotsQuery { SearchTerm = searchTerm });
            if (lotDtos == null || !lotDtos.Any())
            {
                return NotFound(new ApiResponse<object>(StatusCodes.Status404NotFound, ApiMessages.ExportEmpty("Lote próximo de vencimento"), null!));
            }

            var sb = new StringBuilder();
            var culture = CultureInfo.InvariantCulture;

            sb.AppendLine("PRODUTO, DESCRIÇÃO, APRESENTACAO, LOTE, MARCA, QTD_DISPONIVEL, DATA_VENCIMENTO, DIAS_RESTANTES");

            foreach (var lot in lotDtos)
            {
                sb.Append(
                    $"{lot.Product.Name.Replace(";", "")}, " +
                    $"{lot.Product.Description.Replace(";", "")}, " +
                    $"{lot.Product.PresentationFormName}, " +
                    $"{lot.Batch}, " +
                    $"{lot.Brand.Replace(";", "")}, " +
                    $"{lot.AvailableQuantity.ToString("F3", culture)}, " +
                    $"{lot.ExpiryDate:dd/MM/yyyy}, " +
                    $"{lot.DaysRemaining}" +
                    "\r\n"
                );
            }

            var fileName = $"lotes_proximos_vencimento_{DateTime.Now:yyyyMMddHHmmss}.csv";
            var utf8WithBom = new UTF8Encoding(true);
            var fileBytes = utf8WithBom.GetBytes(sb.ToString());

            return File(fileBytes, "text/csv", fileName);
        }

        [HttpGet("export-active-lots")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> ExportActiveStockLots([FromQuery] ExportActiveStockLotsQuery query)
        {
            var lotDtos = await _mediator.Send(query);
            if (lotDtos == null || !lotDtos.Any())
            {
                return NotFound(new ApiResponse<object>(StatusCodes.Status404NotFound, ApiMessages.ExportEmpty("Lote Ativo"), null!));
            }

            var sb = new StringBuilder();
            var culture = CultureInfo.InvariantCulture;

            sb.AppendLine("ID_LOTE, LOTE, PRODUTO, MARCA, QTD_DISPONIVEL, DATA_VENCIMENTO");

            foreach (var lot in lotDtos)
            {
                sb.Append(
                    $"{lot.StockLotId}, " +
                    $"{lot.Batch}, " +
                    $"{lot.Product.Name.Replace(";", "")}, " +
                    $"{lot.Brand.Replace(";", "")}, " +
                    $"{lot.AvailableQuantity.ToString("F3", culture)}, " +
                    $"{lot.ExpiryDate:dd/MM/yyyy}" +
                    "\r\n"
                );
            }

            var fileName = $"lotes_ativos_{DateTime.Now:yyyyMMddHHmmss}.csv";
            var utf8WithBom = new UTF8Encoding(true);
            var fileBytes = utf8WithBom.GetBytes(sb.ToString());

            return File(fileBytes, "text/csv", fileName);
        }

        [HttpGet("export-adjustment")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> ExportAdjustments([FromQuery] ExportStockAdjustmentsQuery query)
        {
            var adjustmentDtos = await _mediator.Send(query);
            if (adjustmentDtos == null || !adjustmentDtos.Any())
            {
                return NotFound(new ApiResponse<object>(StatusCodes.Status404NotFound, ApiMessages.ExportEmpty("Ajuste Manual"), null!));
            }

            var sb = new StringBuilder();
            var separator = ";";
            var culture = new CultureInfo("pt-BR");

            var columns = new[] {
                "ID_AJUSTE", "DATA_AJUSTE", "TIPO", "RAZAO", "RESPONSAVEL", "OBSERVACAO",
                "PRODUTO", "CATEGORIA", "SUB_CATEGORIA", "APRESENTACAO", "LOTE",
                "VALIDADE", "QUANTIDADE", "VALOR_UNITARIO", "VALOR_TOTAL"
            };
            sb.AppendLine(string.Join(separator, columns));

            foreach (var adjustment in adjustmentDtos)
            {
                if (adjustment.AdjustmentItems == null || !adjustment.AdjustmentItems.Any())
                {
                    sb.Append($"{adjustment.Id}{separator}");
                    sb.Append($"{adjustment.AdjustmentDate:dd/MM/yyyy HH:mm:ss}{separator}");
                    sb.Append($"{adjustment.Type}{separator}");
                    sb.Append($"{CleanField(adjustment.Reason)}{separator}");
                    sb.Append($"{CleanField(adjustment.ResponsibleName)}{separator}");
                    sb.Append($"{CleanField(adjustment.Observation)}{separator}");
                    sb.AppendLine($"{separator}{separator}{separator}{separator}{separator}{separator}{separator}{separator}");
                    continue;
                }

                foreach (var item in adjustment.AdjustmentItems)
                {
                    sb.Append($"{adjustment.Id}{separator}");
                    sb.Append($"{adjustment.AdjustmentDate:dd/MM/yyyy HH:mm:ss}{separator}");
                    sb.Append($"{adjustment.Type}{separator}");
                    sb.Append($"{CleanField(adjustment.Reason)}{separator}");
                    sb.Append($"{CleanField(adjustment.ResponsibleName)}{separator}");
                    sb.Append($"{CleanField(adjustment.Observation)}{separator}");

                    sb.Append($"{CleanField(item.Product?.Name)}{separator}");
                    sb.Append($"{CleanField(item.Product?.MainCategoryName)}{separator}");
                    sb.Append($"{CleanField(item.Product?.SubCategoryName)}{separator}");
                    sb.Append($"{CleanField(item.Product?.PresentationFormName)}{separator}");
                    sb.Append($"{CleanField(item.Batch)}{separator}");
                    sb.Append($"{item.ExpiryDate?.ToString("dd/MM/yyyy") ?? ""}{separator}");
                    sb.Append($"{item.Quantity.ToString("F3", culture)}{separator}");
                    sb.Append($"{item.UnitValue?.ToString("F2", culture) ?? "0,00"}{separator}");
                    sb.Append($"{item.TotalValue?.ToString("F2", culture) ?? "0,00"}");

                    sb.Append("\r\n");
                }
            }

            var fileName = $"ajustes_manuais_{DateTime.Now:yyyyMMddHHmmss}.csv";
            var utf8WithBom = new UTF8Encoding(true);
            var fileBytes = utf8WithBom.GetBytes(sb.ToString());

            return File(fileBytes, "text/csv", fileName);
        }

        private string CleanField(string? text)
        {
            if (string.IsNullOrWhiteSpace(text)) return "";

            return text
                .Replace(";", " ")
                .Replace("\r", " ")
                .Replace("\n", " ")
                .Trim();
        }
    }
}
