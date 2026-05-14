using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Features.Receivings.Responses
{
    public sealed record ReceivingListItemResponse(
        int Id,
        string InvoiceNumber,
        string SupplyAuthorization,
        DateTime ReceivingDate,
        decimal TotalValue,
        int SupplierId,
        string SupplierTradeName,
        int ResponsibleId,
        string ResponsibleName,
        int ItemsCount,
        DateTime CreatedOn,
        bool IsActive
    );
}
