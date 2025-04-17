using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using araras_health_hub_api.Dtos.Product;

namespace araras_health_hub_api.Dtos.Receiving
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
