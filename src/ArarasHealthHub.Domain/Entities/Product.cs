using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Domain.Entities
{
    public class Product : BaseEntity
    {
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Description { get; set; } = string.Empty;

        [MaxLength(100)]
        public string DosageForm { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Category { get; set; } = string.Empty;
    }
}
