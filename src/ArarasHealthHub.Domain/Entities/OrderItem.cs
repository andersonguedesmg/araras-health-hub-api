using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Domain.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int RequestedQuantity { get; set; }
        public int ApprovedQuantity { get; set; }
        public int ActualQuantity { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }

        public int OrderId { get; set; }
        public Order? Order { get; set; }
    }
}
