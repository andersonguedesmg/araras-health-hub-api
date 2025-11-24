using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Products.Dtos;

namespace ArarasHealthHub.Application.Features.Stocks.Dtos
{
    public class StockAdjustmentItemDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductDto Product { get; set; } = new ProductDto();
        public decimal Quantity { get; set; }
        public decimal? UnitValue { get; set; }
        public decimal? TotalValue { get; set; }
        public string? Batch { get; set; }
        public string? Brand { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}
