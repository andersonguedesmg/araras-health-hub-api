using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using araras_health_hub_api.Dtos.Product;

namespace araras_health_hub_api.Dtos.Order
{
    public class CreateOrderItemDto
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public ProductDto? Product { get; set; }

        public int RequestedQuantity { get; set; }

        public int ApprovedQuantity { get; set; }

        public int SeparatedQuantity { get; set; }

        public int ActualQuantity { get; set; }

        public int OrderId { get; set; }
    }
}
