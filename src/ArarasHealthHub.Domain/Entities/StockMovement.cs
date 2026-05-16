using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Domain.Exceptions;

namespace ArarasHealthHub.Domain.Entities
{
    public class StockMovement : BaseEntity
    {
        public decimal Quantity { get; private set; }

        public MovementDirectionEnum Direction { get; private set; }

        public MovementReasonEnum Reason { get; private set; }

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
            MovementDirectionEnum direction,
            MovementReasonEnum reason,
            DateTime movementDate,
            int sourceDocumentId,
            string sourceDocumentType,
            int responsibleId,
            int stockLotId,
            decimal movementCost)
        {
            if (quantity <= 0)
                throw new DomainException(
                    "Quantidade deve ser maior que zero."
                );

            if (sourceDocumentId <= 0)
                throw new DomainException(
                    "Documento origem inválido."
                );

            if (string.IsNullOrWhiteSpace(sourceDocumentType))
                throw new DomainException(
                    "Tipo documento origem obrigatório."
                );

            if (movementCost < 0)
                throw new DomainException(
                    "Custo movimentação inválido."
                );

            Quantity = quantity;
            Direction = direction;
            Reason = reason;
            MovementDate = movementDate;
            SourceDocumentId = sourceDocumentId;
            SourceDocumentType = sourceDocumentType.Trim();
            ResponsibleId = responsibleId;
            StockLotId = stockLotId;
            MovementCost = movementCost;
        }
    }
}
