using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Domain.Identity;

namespace ArarasHealthHub.Domain.Entities
{
    public class Facility : BaseEntity
    {
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(200)]
        public string Address { get; set; } = string.Empty;

        [MaxLength(20)]
        public string Number { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Neighborhood { get; set; } = string.Empty;

        [MaxLength(100)]
        public string City { get; set; } = string.Empty;

        [MaxLength(2)]
        public string State { get; set; } = string.Empty;

        [MaxLength(10)]
        public string Cep { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [MaxLength(20)]
        public string Phone { get; set; } = string.Empty;

        public ICollection<ApplicationUser> Accounts { get; set; } = new List<ApplicationUser>();

        public Facility() : base() { }

        public Facility(int id, string name, string address, string number, string neighborhood, string city, string state, string cep, string email, string phone, DateTime createdOn, DateTime? updatedOn, bool isActive)
        {
            Id = id;
            CreatedOn = createdOn;
            UpdatedOn = updatedOn;
            IsActive = isActive;

            Name = name;
            Address = address;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Cep = cep;
            Email = email;
            Phone = phone;
        }
    }
}
