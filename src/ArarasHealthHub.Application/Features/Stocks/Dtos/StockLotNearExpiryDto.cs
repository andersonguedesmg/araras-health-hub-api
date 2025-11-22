using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Products.Dtos;

namespace ArarasHealthHub.Application.Features.Stocks.Dtos
{
    public class StockLotNearExpiryDto
    {
        public int StockLotId { get; set; }
        public int ProductId { get; set; }
        public ProductDto Product { get; set; } = new ProductDto();
        public string Batch { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public decimal AvailableQuantity { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int DaysRemaining { get; set; }
    }
}
