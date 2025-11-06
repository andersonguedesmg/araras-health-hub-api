using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Domain.Entities
{
    [Comment("Registra os lotes específicos usados para atender um item de pedido durante a separação.")]
    public class OrderItemLot
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey("OrderItem")]
        public int OrderItemId { get; set; }
        public OrderItem OrderItem { get; set; } = null!;

        [Required]
        [ForeignKey("StockLot")]
        public int StockLotId { get; set; }
        public StockLot StockLot { get; set; } = null!;

        [Required]
        [Column(TypeName = "decimal(18,3)")]
        [Comment("Quantidade real baixada deste lote para atender o pedido.")]
        public decimal Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Comment("Valor unitário do produto no momento da baixa, herdado do StockLot.")]
        public decimal UnitValue { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Comment("Custo total do item (Quantity * UnitValue) para fins de relatório.")]
        public decimal TotalValue { get; set; }
    }
}
