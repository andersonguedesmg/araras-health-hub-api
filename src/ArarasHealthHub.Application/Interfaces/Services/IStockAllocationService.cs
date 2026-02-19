using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared;

using static ArarasHealthHub.Application.Services.StockAllocation.StockAllocationDtos;

namespace ArarasHealthHub.Application.Interfaces.Services
{
    public interface IStockAllocationService
    {
        Task<ApiResponseO<StockAllocationResult>> AllocateFeFo(int productId, decimal quantityToAllocate, CancellationToken cancellationToken);

        Task<int?> FindStockLotIdByProductAttributes(int productId, string batch, string brand, CancellationToken cancellationToken);

        Task<List<StockMovement>> PerformStockExit(
            StockAllocationResult allocationResult,
            int responsibleId,
            int sourceDocumentId,
            string sourceDocumentType,
            CancellationToken cancellationToken
        );
    }
}
