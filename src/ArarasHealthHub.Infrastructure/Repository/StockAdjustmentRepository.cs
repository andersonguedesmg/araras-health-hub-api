using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Infrastructure.Data;

namespace ArarasHealthHub.Infrastructure.Repository
{
    public class StockAdjustmentRepository : BaseRepository<StockAdjustment>, IStockAdjustmentRepository
    {
        public StockAdjustmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
