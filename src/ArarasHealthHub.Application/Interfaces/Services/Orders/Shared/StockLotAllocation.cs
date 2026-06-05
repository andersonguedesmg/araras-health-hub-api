using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Entities;

namespace ArarasHealthHub.Application.Interfaces.Services.Orders.Shared
{
    public sealed record StockLotAllocation(
        StockLot StockLot,
        decimal Quantity
    );
}
