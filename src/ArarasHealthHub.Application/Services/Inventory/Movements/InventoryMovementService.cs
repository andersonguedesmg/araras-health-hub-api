using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Application.Interfaces.Services.Inventory.Movements;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Domain.Enums;

namespace ArarasHealthHub.Application.Services.Inventory.Movements
{
    public class InventoryMovementService : IInventoryMovementService
    {
        private readonly IApplicationDbContext _dbContext;

        public InventoryMovementService(
            IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateMovementAsync(
            StockLot stockLot,
            decimal quantity,
            MovementDirectionEnum direction,
            MovementReasonEnum reason,
            DateTime movementDate,
            int sourceDocumentId,
            string sourceDocumentType,
            int responsibleId,
            decimal movementCost,
            CancellationToken cancellationToken)
        {
            var movement = new StockMovement(
                quantity: quantity,
                direction: direction,
                reason: reason,
                movementDate: movementDate,
                sourceDocumentId: sourceDocumentId,
                sourceDocumentType: sourceDocumentType,
                responsibleId: responsibleId,
                stockLotId: stockLot.Id,
                movementCost: movementCost
            );

            await _dbContext.StockMovements.AddAsync(
                movement,
                cancellationToken);
        }
    }
}
