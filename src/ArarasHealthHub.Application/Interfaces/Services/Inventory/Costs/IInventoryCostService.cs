using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Entities;

namespace ArarasHealthHub.Application.Interfaces.Services.Inventory.Costs
{
    public interface IInventoryCostService
    {
        void ProcessEntryCost(
            Stock stock,
            decimal entryQuantity,
            decimal entryUnitCost);

        void ProcessOutputCost(
            Stock stock,
            decimal outputQuantity);
    }
}
