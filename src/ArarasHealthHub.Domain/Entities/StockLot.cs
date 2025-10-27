using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Domain.Entities
{
    [Comment("Representa o estoque detalhado de um produto por lote, valor e validade.")]
    [Index(nameof(StockId), nameof(Batch), IsUnique = true)]
    public class StockLot : BaseEntity
    {
        [Required]
        [ForeignKey("Stock")]
        [Comment("ID do registro consolidado de estoque (Stock) a que este lote pertence.")]
        public int StockId { get; set; }
        public Stock Stock { get; set; } = null!;

        [NotMapped]
        public int ProductId => Stock.ProductId;

        [Required]
        [MaxLength(50)]
        [Comment("Número/Código do lote do produto.")]
        public string Batch { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Comment("Custo unitário deste lote (custo de entrada).")]
        public decimal UnitValue { get; set; }

        [Required]
        [Comment("Data de vencimento deste lote.")]
        public DateTime ExpiryDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,3)")]
        [Comment("Quantidade disponível em estoque para este lote.")]
        public decimal AvailableQuantity { get; set; }

        [ForeignKey("ReceivedItem")]
        [Comment("Opcional: ID do Item do Recebimento que deu origem a este lote (para rastreio).")]
        public int? ReceivedItemId { get; set; }
        public ReceivedItem? ReceivedItem { get; set; }

        public void AddQuantity(decimal quantity)
        {
            if (quantity <= 0) return;
            AvailableQuantity += quantity;
            SetUpdatedOn();
        }

        public void RemoveQuantity(decimal quantity)
        {
            if (quantity <= 0) return;
            if (AvailableQuantity < quantity)
            {
                throw new ApplicationException($"Baixa de {quantity} excede a quantidade disponível ({AvailableQuantity}) neste lote ({Batch}).");
            }
            AvailableQuantity -= quantity;
            SetUpdatedOn();
        }
    }
}
