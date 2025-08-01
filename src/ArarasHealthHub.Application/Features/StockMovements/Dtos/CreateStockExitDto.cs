using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Features.StockMovements.Dtos
{
    public class CreateStockExitDto
    {
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public int SourceDocumentId { get; set; }
        public string SourceDocumentType { get; set; } = string.Empty;
        public int ResponsibleId { get; set; }
    }
}
