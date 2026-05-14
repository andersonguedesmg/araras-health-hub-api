using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Accounts.Responses;
using ArarasHealthHub.Application.Features.Employees.Responses;
using ArarasHealthHub.Application.Features.SubCategories.Responses;

namespace ArarasHealthHub.Application.Features.Receivings.Responses
{
    public sealed record ReceivingResponse(
        int Id,
        string InvoiceNumber,
        string SupplyAuthorization,
        string? Observation,
        DateTime ReceivingDate,
        decimal TotalValue,

        int SupplierId,
        SupplierResponse? Supplier,

        int ResponsibleId,
        EmployeeResponse? Responsible,

        int AccountId,
        AccountMinimalResponse? Account,

        IReadOnlyCollection<ReceivingItemResponse> Items,

        DateTime CreatedOn,
        DateTime? UpdatedOn,
        bool IsActive
    );
}
