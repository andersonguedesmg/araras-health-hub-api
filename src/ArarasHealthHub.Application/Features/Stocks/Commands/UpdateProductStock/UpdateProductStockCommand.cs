using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Shared.Core;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;

namespace ArarasHealthHub.Application.Features.Stocks.Commands.UpdateProductStock
{
    public record UpdateProductStockCommand(
        int ProductId,
        decimal Quantity,
        StockOperationTypeEnum OperationType
    ) : IRequest<ApiResponseO<Stock>>;
}
