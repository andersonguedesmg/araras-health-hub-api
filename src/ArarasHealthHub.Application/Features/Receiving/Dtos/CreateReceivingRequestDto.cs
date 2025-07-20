using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Features.Receiving.Dtos
{
    public class CreateReceivingRequestDto
    {
        public string InvoiceNumber { get; set; } = string.Empty;

        public string SupplyAuthorization { get; set; } = string.Empty;

        public string Observation { get; set; } = string.Empty;

        public DateTime ReceivingDate { get; set; }

        public decimal TotalValue { get; set; }

        public int SupplierId { get; set; }

        public int ResponsibleId { get; set; }

        public int AccountId { get; set; }

        public List<CreateReceivingItemDto>? ReceivedItems { get; set; }
    }
}
