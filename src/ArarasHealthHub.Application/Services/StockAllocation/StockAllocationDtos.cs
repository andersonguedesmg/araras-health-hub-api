using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Services.StockAllocation
{
    public class StockAllocationDtos
    {
        public record AllocatedLotDetail(
            int StockLotId,
            decimal QuantityAllocated
        );

        public record StockAllocationResult(
            int ProductId,
            decimal RequestedQuantity,
            List<AllocatedLotDetail> LotDetails
        )
        {
            public bool IsFullyAllocated => LotDetails.Sum(d => d.QuantityAllocated) == RequestedQuantity;
        }
    }
}
