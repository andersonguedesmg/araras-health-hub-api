using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.StockMovements.Dtos;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;

namespace ArarasHealthHub.Application.Features.StockMovements.Commands.CreateStockMovement
{
    public record CreateStockMovementCommand(
        int ProductId,
        decimal Quantity,
        int StockLotId,
        int SourceDocumentId,
        string SourceDocumentType,
        int ResponsibleId,
        MovementTypeEnum MovementType,
        decimal MovementCost,
        DateTime MovementDate
    ) : IRequest<ApiResponse<StockMovementDto>>;
}
