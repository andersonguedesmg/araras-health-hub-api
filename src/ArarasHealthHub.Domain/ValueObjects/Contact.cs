using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Domain.ValueObjects
{
    [Owned]
    public class Contact
    {
        [Required]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string Phone { get; set; } = string.Empty;

        public Contact() { }

        public Contact(string email, string phone)
        {
            Email = email;
            Phone = phone;
        }
    }
}
