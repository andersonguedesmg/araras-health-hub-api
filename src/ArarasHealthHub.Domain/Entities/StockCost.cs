using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Domain.Entities
{
    public class StockCost : BaseEntity
    {
        public int StockId { get; private set; }
        public Stock Stock { get; private set; } = null!;

        public decimal AverageUnitCost { get; private set; }
        public decimal CurrentTotalCost { get; private set; }

        private StockCost() { }

        public StockCost(
            int stockId,
            decimal averageUnitCost,
            decimal currentTotalCost)
        {
            StockId = stockId;
            AverageUnitCost = averageUnitCost;
            CurrentTotalCost = currentTotalCost;
        }

        public void UpdateCosts(decimal averageUnitCost, decimal totalCost)
        {
            AverageUnitCost = averageUnitCost;
            CurrentTotalCost = totalCost;
        }
    }
}
