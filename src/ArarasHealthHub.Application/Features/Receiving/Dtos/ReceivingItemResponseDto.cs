using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Product.Dtos;

namespace ArarasHealthHub.Application.Features.Receiving.Dtos
{
    public class ReceivingItemResponseDto
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public ProductDto? Product { get; set; }

        public int Quantity { get; set; }

        public decimal UnitValue { get; set; }

        public decimal TotalValue { get; set; }

        public string Batch { get; set; } = string.Empty;

        public DateTime ExpiryDate { get; set; }
    }
}
