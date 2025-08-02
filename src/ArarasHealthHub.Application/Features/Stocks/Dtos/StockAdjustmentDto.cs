using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Features.Stocks.Dtos
{
    public class StockAdjustmentDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public string? Reason { get; set; }
        public int ResponsibleId { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
