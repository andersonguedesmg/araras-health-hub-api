using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace araras_health_hub_api.Dtos.Receiving
{
    public class CreateReceivingRequestDto
    {
        public string InvoiceNumber { get; set; } = string.Empty;

        public string SupplyAuthorization { get; set; } = string.Empty;

        public string Observations { get; set; } = string.Empty;

        public DateTime ReceivingDate { get; set; }

        public int SupplierId { get; set; }

        public int ResponsibleId { get; set; }

        public int AccountId { get; set; }

        public List<CreateReceivingItemDto>? ReceivedItems { get; set; }
    }
}
