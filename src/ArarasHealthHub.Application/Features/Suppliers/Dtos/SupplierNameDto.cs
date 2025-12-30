using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Features.Suppliers.Dtos
{
    public class SupplierNameDto
    {
        public int Id { get; set; }
        public string LegalName { get; set; } = string.Empty;
        public string TradeName { get; set; } = string.Empty;
    }
}
