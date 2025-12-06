using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Domain.Entities;

namespace ArarasHealthHub.Application.Interfaces.Repositories
{
    public interface IStockLotRepository : IBaseRepository<StockLot>
    {
        Task<StockLot?> GetByStockIdAndBatchAndBrandAsync(int stockId, string batch, string brand);
        Task<IEnumerable<StockLot>> GetAvailableLotsByProductIdFEFOAsync(int productId);
    }
}
