using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.ValueObjects;

namespace ArarasHealthHub.Domain.Entities
{
    public class Supplier : BaseEntity
    {
        public string LegalName { get; private set; } = string.Empty;
        public string TradeName { get; private set; } = string.Empty;
        public string Cnpj { get; private set; } = string.Empty;

        public Address Address { get; private set; } = null!;
        public Contact Contact { get; private set; } = null!;

        private Supplier() { }

        public Supplier(
            string legalName,
            string tradeName,
            string cnpj,
            Address address,
            Contact contact)
        {
            LegalName = legalName;
            TradeName = tradeName;
            Cnpj = cnpj;
            Address = address ?? throw new ArgumentNullException(nameof(address));
            Contact = contact ?? throw new ArgumentNullException(nameof(contact));
        }

        public void Update(
            string legalName,
            string tradeName,
            Address address,
            Contact contact)
        {
            LegalName = legalName;
            TradeName = tradeName;
            Address = address ?? throw new ArgumentNullException(nameof(address));
            Contact = contact ?? throw new ArgumentNullException(nameof(contact));
        }
    }
}
