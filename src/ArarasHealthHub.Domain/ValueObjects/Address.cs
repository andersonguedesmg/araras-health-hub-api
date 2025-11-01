using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Domain.ValueObjects
{
    [Owned]
    public class Address
    {
        [Required]
        [MaxLength(10)]
        public string Cep { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string Street { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? Complement { get; set; }

        [Required]
        [MaxLength(20)]
        public string Number { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Neighborhood { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string City { get; set; } = string.Empty;

        [Required]
        [MaxLength(2)]
        public string State { get; set; } = string.Empty;

        public Address() { }

        public Address(string cep, string street, string number, string neighborhood, string city, string state, string? complement = null)
        {
            Cep = cep;
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Complement = complement;
        }
    }
}
