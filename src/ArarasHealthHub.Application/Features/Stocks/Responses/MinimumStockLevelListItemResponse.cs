using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Features.Stocks.Responses
{
    public record MinimumStockLevelListItemResponse(
        int Id,
        int ProductId,
        string ProductName,
        string MainCategory,
        string SubCategory,
        string PackagingType,
        decimal CurrentQuantity,
        decimal MinimumStockLevel,
        bool IsActive
    );
}
