using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Domain.Enums;

namespace ArarasHealthHub.Application.Features.StockMovements.Dtos
{
    public class StockMovementDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public MovementTypeEnum Type { get; set; }
        public int SourceDocumentId { get; set; }
        public string SourceDocumentType { get; set; } = string.Empty;
        public string ResponsibleName { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
    }
}
