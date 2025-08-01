using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.StockMovements.Dtos;
using ArarasHealthHub.Shared.Core;
using MediatR;

namespace ArarasHealthHub.Application.Features.StockMovements.Commands.CreateStockExit
{
    public record CreateStockExitCommand(
        int ProductId,
        decimal Quantity,
        int SourceDocumentId,
        string SourceDocumentType,
        int ResponsibleId
    ) : IRequest<ApiResponse<StockMovementDto>>;
}
