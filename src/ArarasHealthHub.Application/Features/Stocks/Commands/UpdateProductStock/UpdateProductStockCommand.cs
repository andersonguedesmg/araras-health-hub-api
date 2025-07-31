using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Interfaces;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Shared.Core;
using MediatR;

namespace ArarasHealthHub.Application.Features.Stocks.Commands.UpdateProductStock
{
    public record UpdateProductStockCommand(
        int ProductId,
        decimal Quantity,
        StockOperationTypeEnum OperationType
    ) : IRequest<ApiResponse<bool>>;
}
