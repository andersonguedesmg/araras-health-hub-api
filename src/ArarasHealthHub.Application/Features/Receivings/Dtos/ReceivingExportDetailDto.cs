using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Features.Receivings.Dtos
{
    public class ReceivingExportDetailDto
    {
        public int ReceivingId { get; set; }
        public string? InvoiceNumber { get; set; }
        public string? SupplyAuthorization { get; set; }
        public DateTime ReceivingDate { get; set; }
        public string? SupplierName { get; set; }
        public string? ResponsibleName { get; set; }
        public string? Observation { get; set; }

        public string? ProductName { get; set; }
        public string? Batch { get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal QuantityReceived { get; set; }
        public decimal UnitValue { get; set; }
        public decimal ItemTotalValue => QuantityReceived * UnitValue;
    }
}
