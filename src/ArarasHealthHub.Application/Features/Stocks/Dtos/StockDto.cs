using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Products.Dtos;

namespace ArarasHealthHub.Application.Features.Stocks.Dtos
{
    public record StockDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductDto Product { get; set; } = null!;
        public decimal CurrentQuantity { get; set; }
        public decimal MinQuantity { get; set; }
    }
}
