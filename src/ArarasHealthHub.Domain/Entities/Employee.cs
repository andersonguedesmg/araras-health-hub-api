using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Domain.Entities
{
    public class Employee : BaseEntity
    {
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(14)]
        public string Cpf { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Function { get; set; } = string.Empty;

        [MaxLength(20)]
        public string Phone { get; set; } = string.Empty;
    }
}
