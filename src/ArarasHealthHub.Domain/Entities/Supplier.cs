using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Domain.Entities
{
    [Comment("Representa um fornecedor.")]
    public class Supplier : BaseEntity
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(18)]
        public string Cnpj { get; set; } = string.Empty;

        [Required]
        public Address Address { get; set; } = new Address();

        [Required]
        public Contact Contact { get; set; } = new Contact();
    }
}
