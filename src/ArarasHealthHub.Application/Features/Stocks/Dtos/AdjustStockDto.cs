using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Features.Stocks.Dtos
{
    public class AdjustStockDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Reason { get; set; } = string.Empty;
        public int AdjustedByEmployeeId { get; set; }
        public int AdjustedByAccountId { get; set; }
    }
}
