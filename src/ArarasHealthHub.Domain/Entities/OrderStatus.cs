using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Domain.Entities
{
    [Comment("Tabela de lookup para os status possíveis de um pedido.")]
    public class OrderStatus
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; } = string.Empty;
    }
}
