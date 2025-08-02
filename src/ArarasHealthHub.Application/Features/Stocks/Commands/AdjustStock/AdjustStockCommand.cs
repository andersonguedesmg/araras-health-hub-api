using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Interfaces;
using ArarasHealthHub.Shared.Core;
using MediatR;

namespace ArarasHealthHub.Application.Features.Stocks.Commands.AdjustStock
{
    public record AdjustStockCommand(
        int ProductId,
        int Quantity,
        string Reason,
        int AdjustedByEmployeeId,
        int AdjustedByAccountId
    ) : IRequest<ApiResponse<bool>>, ITransactionalRequest;
}
