using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Domain.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal RequestedQuantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ApprovedQuantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ReservedQuantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ActualQuantity { get; set; }

        [Required]
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        [Required]
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order? Order { get; set; }

        public List<OrderItemLot> OrderItemLots { get; set; } = new();
    }
}
