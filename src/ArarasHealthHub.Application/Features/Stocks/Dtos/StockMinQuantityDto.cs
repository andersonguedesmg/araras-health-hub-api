using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Features.Stocks.Dtos
{
    public class StockMinQuantityDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal MinQuantity { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductCode { get; set; } = string.Empty;
        public bool ProductIsActive { get; set; }
    }
}
