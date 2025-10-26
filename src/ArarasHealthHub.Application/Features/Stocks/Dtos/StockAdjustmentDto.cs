using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Features.Stocks.Dtos
{
    public class StockAdjustmentDto
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;
        public string? Observation { get; set; }
        public DateTime AdjustmentDate { get; set; }
        public string ResponsibleName { get; set; } = string.Empty;
        public ICollection<StockAdjustmentItemDto> AdjustmentItems { get; set; } = new List<StockAdjustmentItemDto>();
    }
}
