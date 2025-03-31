using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace araras_health_hub_api.Dtos.Receiving
{
    public class ReceivingItemResponseDto
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public string Batch { get; set; } = string.Empty;

        public DateTime ExpiryDate { get; set; }

        public DateTime ManufacturingDate { get; set; }
    }
}
