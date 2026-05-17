using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Stocks.Commands.SetMinimumStockLevel
{
    public record SetMinimumStockLevelCommand(int ProductId, decimal MinimumQuantity) : IRequest<Result>;
}
