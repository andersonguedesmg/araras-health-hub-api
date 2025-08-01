using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Domain.Enums;

namespace ArarasHealthHub.Domain.Entities
{
    public class StockMovement : BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public decimal Quantity { get; set; }
        public MovementTypeEnum Type { get; set; }
        public int SourceDocumentId { get; set; }
        public string SourceDocumentType { get; set; } = string.Empty;
        public int ResponsibleId { get; set; }
        public Employee Responsible { get; set; } = null!;
    }
}
