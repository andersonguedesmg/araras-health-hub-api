using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Identity;
using ArarasHealthHub.Domain.ValueObjects;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Domain.Entities
{
    [Comment("Representa uma unidade.")]
    public class Facility : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(7)]
        public string Cnes { get; set; } = string.Empty;

        [Required]
        public Address Address { get; set; } = new Address();

        [Required]
        public Contact Contact { get; set; } = new Contact();

        public ICollection<ApplicationUser> Accounts { get; set; } = new List<ApplicationUser>();

        public Facility() : base() { }
    }
}
