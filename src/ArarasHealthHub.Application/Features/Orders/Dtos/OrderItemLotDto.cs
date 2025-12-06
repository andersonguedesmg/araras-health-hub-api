using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Features.Orders.Dtos
{
    public class OrderItemLotDto
    {
        public int StockLotId { get; set; }
        public string Batch { get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set; }
        public decimal QuantityToSeparate { get; set; }
        public decimal UnitValue { get; set; }
    }
}
