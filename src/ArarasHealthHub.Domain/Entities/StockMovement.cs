using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Domain.Entities
{
    [Comment("Representa uma entrada ou saída de itens do estoque.")]
    public class StockMovement : BaseEntity
    {
        [Required]
        [Column(TypeName = "decimal(18,3)")]
        public decimal Quantity { get; set; }

        [Required]
        public MovementTypeEnum Type { get; set; }

        [Required]
        [Comment("Data em que a movimentação de estoque ocorreu.")]
        public DateTime MovementDate { get; set; }

        [Required]
        [Comment("ID do documento de origem (ex: OrderId, ReceivingId).")]
        public int SourceDocumentId { get; set; }

        [Required]
        [MaxLength(50)]
        [Comment("Tipo do documento de origem (ex: 'Order', 'Receiving').")]
        public string SourceDocumentType { get; set; } = string.Empty;

        [Required]
        [ForeignKey("Responsible")]
        public int ResponsibleId { get; set; }
        public Employee Responsible { get; set; } = null!;

        [Required]
        [ForeignKey("StockLot")]
        [Comment("ID do Lote de Estoque afetado pela movimentação.")]
        public int StockLotId { get; set; }
        public StockLot StockLot { get; set; } = null!;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Comment("O custo financeiro da quantidade movimentada.")]
        public decimal MovementCost { get; set; }

        [NotMapped]
        public int ProductId => StockLot.Stock.ProductId;
    }
}
