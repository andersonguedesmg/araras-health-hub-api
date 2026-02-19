using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Shared;
using ArarasHealthHub.Shared.Responses;

using MediatR;

namespace ArarasHealthHub.Application.Features.Stocks.Commands.UpdateStockReservation
{
    public record UpdateStockReservationCommand(
        int ProductId,
        decimal QuantityToReserve
    ) : IRequest<ApiResponseO<bool>>;
}
