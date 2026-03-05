using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Identity;
using ArarasHealthHub.Domain.ValueObjects;

namespace ArarasHealthHub.Domain.Entities
{
    public class Facility : BaseEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string Cnes { get; private set; } = string.Empty;

        public Address Address { get; private set; } = null!;
        public Contact Contact { get; private set; } = null!;

        public ICollection<ApplicationUser> Accounts { get; private set; } = new List<ApplicationUser>();

        private Facility() { }

        public Facility(string name, string cnes, Address address, Contact contact)
        {
            Name = name;
            Cnes = cnes;
            Address = address ?? throw new ArgumentNullException(nameof(address));
            Contact = contact ?? throw new ArgumentNullException(nameof(contact));
        }

        public void Update(string name, string cnes, Address address, Contact contact)
        {
            Name = name;
            Cnes = cnes;
            Address = address ?? throw new ArgumentNullException(nameof(address));
            Contact = contact ?? throw new ArgumentNullException(nameof(contact));
        }
    }
}
