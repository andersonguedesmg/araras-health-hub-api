using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Accounts.Dtos;
using ArarasHealthHub.Application.Features.Employees.Dtos;
using ArarasHealthHub.Application.Features.Suppliers.Dtos;

namespace ArarasHealthHub.Application.Features.Receivings.Dtos
{
    public class ReceivingDto
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
        public string SupplyAuthorization { get; set; } = string.Empty;
        public string? Observation { get; set; }
        public DateTime ReceivingDate { get; set; }
        public decimal TotalValue { get; set; }

        public int SupplierId { get; set; }
        public int ResponsibleId { get; set; }
        public int AccountId { get; set; }

        public SupplierDto? Supplier { get; set; }
        public EmployeeDto? Responsible { get; set; }
        public AccountDto? Account { get; set; }

        public List<ReceivedItemDto> ReceivedItem { get; set; } = new();

        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
