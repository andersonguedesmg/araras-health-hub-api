using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Products.Responses;

namespace ArarasHealthHub.Application.Features.Receivings.Responses
{
    public sealed record ReceivingItemResponse(
        int Id,

        decimal Quantity,

        decimal UnitValue,

        decimal TotalValue,

        string Batch,

        string Brand,

        DateTime ExpiryDate,

        int ProductId,

        ProductResponse Product,

        DateTime CreatedOn,

        DateTime? UpdatedOn,

        bool IsActive
    );
}
