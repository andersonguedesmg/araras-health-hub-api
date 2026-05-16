using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Domain.Enums;

namespace ArarasHealthHub.Application.Interfaces.Services.Inventory.Movements
{
    public interface IInventoryMovementService
    {
        Task CreateMovementAsync(
            StockLot stockLot,
            decimal quantity,
            MovementDirectionEnum direction,
            MovementReasonEnum reason,
            DateTime movementDate,
            int sourceDocumentId,
            string sourceDocumentType,
            int responsibleId,
            decimal movementCost,
            CancellationToken cancellationToken);
    }
}
