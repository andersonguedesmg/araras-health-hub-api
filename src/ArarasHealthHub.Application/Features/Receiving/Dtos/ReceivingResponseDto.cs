using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Employees.Dtos;
using ArarasHealthHub.Application.Features.Suppliers.Dtos;
using ArarasHealthHub.Domain.Identity;

namespace ArarasHealthHub.Application.Features.Receiving.Dtos
{
    public class ReceivingResponseDto
    {
        public int Id { get; set; }

        public int SupplierId { get; set; }

        public SupplierDto? Supplier { get; set; }

        public DateTime ReceivingDate { get; set; }

        public string InvoiceNumber { get; set; } = string.Empty;

        public string SupplyAuthorization { get; set; } = string.Empty;

        public decimal TotalValue { get; set; }

        public EmployeeDto? Responsible { get; set; }

        public int ResponsibleId { get; set; }

        public int AccountId { get; set; }

        public ApplicationUser? Account { get; set; }

        public string Observation { get; set; } = string.Empty;

        public List<ReceivingItemResponseDto> ReceivedItems { get; set; } = new();
    }
}
