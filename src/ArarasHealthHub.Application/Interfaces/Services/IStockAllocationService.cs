using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Core;
using static ArarasHealthHub.Application.Services.StockAllocation.StockAllocationDtos;

namespace ArarasHealthHub.Application.Interfaces.Services
{
    public interface IStockAllocationService
    {
        Task<ApiResponse<StockAllocationResult>> AllocateFeFo(int productId, decimal quantityToAllocate);

        Task<List<StockMovement>> PerformStockExit(
            StockAllocationResult allocationResult,
            int responsibleId,
            int sourceDocumentId,
            string sourceDocumentType
        );
    }
}
