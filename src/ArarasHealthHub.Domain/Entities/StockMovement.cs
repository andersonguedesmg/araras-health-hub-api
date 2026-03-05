using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Enums;

namespace ArarasHealthHub.Domain.Entities
{
    public class StockMovement : BaseEntity
    {
        public decimal Quantity { get; private set; }

        public MovementTypeEnum Type { get; private set; }

        public DateTime MovementDate { get; private set; }

        public int SourceDocumentId { get; private set; }

        public string SourceDocumentType { get; private set; } = string.Empty;

        public int ResponsibleId { get; private set; }
        public Employee Responsible { get; private set; } = null!;

        public int StockLotId { get; private set; }
        public StockLot StockLot { get; private set; } = null!;

        public decimal MovementCost { get; private set; }

        private StockMovement() { }

        public StockMovement(
            decimal quantity,
            MovementTypeEnum type,
            DateTime movementDate,
            int sourceDocumentId,
            string sourceDocumentType,
            int responsibleId,
            int stockLotId,
            decimal movementCost)
        {
            Quantity = quantity;
            Type = type;
            MovementDate = movementDate;
            SourceDocumentId = sourceDocumentId;
            SourceDocumentType = sourceDocumentType;
            ResponsibleId = responsibleId;
            StockLotId = stockLotId;
            MovementCost = movementCost;
        }
    }
}
