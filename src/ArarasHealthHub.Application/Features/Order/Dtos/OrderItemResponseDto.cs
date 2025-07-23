using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Products.Dtos;

namespace ArarasHealthHub.Application.Features.Order.Dtos
{
    public class OrderItemResponseDto
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public OrderDto? Order { get; set; }

        public int ProductId { get; set; }
        public ProductDto? Product { get; set; }

        public int RequestedQuantity { get; set; }
        public int ApprovedQuantity { get; set; }
        public int ActualQuantity { get; set; }
    }
}
