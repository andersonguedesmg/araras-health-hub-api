using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Services.Inventory.Costs;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Domain.Exceptions;

namespace ArarasHealthHub.Application.Services.Inventory.Costs
{
    public class InventoryCostService : IInventoryCostService
    {
        public void ProcessEntryCost(
            Stock stock,
            decimal entryQuantity,
            decimal entryUnitCost)
        {
            if (entryQuantity <= 0)
                throw new DomainException(
                    "Quantidade deve ser maior que zero.");

            if (entryUnitCost < 0)
                throw new DomainException(
                    "Valor unitário não pode ser negativo.");

            if (stock.StockCost is null)
            {
                var totalCost =
                    entryQuantity * entryUnitCost;

                stock.InitializeCost(
                    averageUnitCost: entryUnitCost,
                    currentTotalCost: totalCost);

                return;
            }

            var previousQuantity =
                stock.CurrentQuantity - entryQuantity;

            if (previousQuantity <= 0)
            {
                var totalCost =
                    entryQuantity * entryUnitCost;

                stock.StockCost.Recalculate(
                    entryUnitCost,
                    totalCost);

                return;
            }

            var currentTotalCost =
                stock.StockCost.CurrentTotalCost;

            var entryTotalCost =
                entryQuantity * entryUnitCost;

            var newTotalQuantity =
                previousQuantity + entryQuantity;

            var newTotalCost =
                currentTotalCost + entryTotalCost;

            var newAverageCost =
                newTotalCost / newTotalQuantity;

            stock.StockCost.Recalculate(
                newAverageCost,
                newTotalCost);
        }

        public void ProcessOutputCost(
            Stock stock,
            decimal outputQuantity)
        {
            if (outputQuantity <= 0)
            {
                throw new DomainException(
                    "Quantidade saída inválida.");
            }

            if (stock.StockCost is null)
            {
                return;
            }

            var movementCost =
                stock.StockCost.AverageUnitCost *
                outputQuantity;

            var newTotalCost =
                stock.StockCost.CurrentTotalCost -
                movementCost;

            if (newTotalCost < 0)
            {
                newTotalCost = 0;
            }

            if (stock.CurrentQuantity <= 0)
            {
                stock.StockCost.Recalculate(0, 0);

                return;
            }

            stock.StockCost.Recalculate(
                stock.StockCost.AverageUnitCost,
                newTotalCost);
        }
    }
}
