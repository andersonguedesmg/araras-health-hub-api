using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Exceptions;

namespace ArarasHealthHub.Domain.Entities
{
    public class StockCost : BaseEntity
    {
        public int StockId { get; private set; }

        public Stock Stock { get; private set; } = null!;

        public decimal AverageUnitCost { get; private set; }

        public decimal CurrentTotalCost { get; private set; }

        private StockCost() { }

        public StockCost(int stockId)
        {
            if (stockId <= 0)
                throw new DomainException("Estoque inválido.");

            StockId = stockId;
        }

        public void Recalculate(
            decimal averageUnitCost,
            decimal currentTotalCost)
        {
            if (averageUnitCost < 0)
            {
                throw new DomainException(
                    "Custo médio não pode ser negativo."
                );
            }

            if (currentTotalCost < 0)
            {
                throw new DomainException(
                    "Custo total não pode ser negativo."
                );
            }

            AverageUnitCost = averageUnitCost;
            CurrentTotalCost = currentTotalCost;

            SetUpdatedOn();
        }
    }
}
