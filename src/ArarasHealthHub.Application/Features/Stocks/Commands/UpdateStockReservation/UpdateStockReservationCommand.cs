using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Shared.Core;
using MediatR;

namespace ArarasHealthHub.Application.Features.Stocks.Commands.UpdateStockReservation
{
    public record UpdateStockReservationCommand(
        int ProductId,
        decimal QuantityToReserve
    ) : IRequest<ApiResponse<bool>>;
}
