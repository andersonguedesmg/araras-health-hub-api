using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using araras_health_hub_api.Dtos.Supplier;
using araras_health_hub_api.Dtos.User;
using araras_health_hub_api.Models;

namespace araras_health_hub_api.Dtos.Receiving
{
    public class ReceivingResponseDto
    {
        public int Id { get; set; }

        public int SupplierId { get; set; }

        public SupplierDto? Supplier { get; set; }

        public DateTime ReceivingDate { get; set; }

        public string InvoiceNumber { get; set; } = string.Empty;

        public string SupplyAuthorization { get; set; } = string.Empty;

        public UserDto? Responsible { get; set; }

        public int ResponsibleId { get; set; }

        public int AccountId { get; set; }

        public AppUser? Account { get; set; }

        public string Observations { get; set; } = string.Empty;

        public List<ReceivingItemResponseDto>? ReceivedItems { get; set; }
    }
}
