using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Features.Dashboards.Dtos
{
    public class DashboardSummaryDto
    {
        public int PendingApprovalCount { get; set; }
        public int PendingSeparationCount { get; set; }
        public int PendingDeliveryCount { get; set; }
        public int CriticalStockCount { get; set; }
        public int TotalActiveProducts { get; set; }

        public List<MonthlyEvolutionDto> MonthlyEvolution { get; set; } = new();
        public List<CategoryDistributionDto> CategoryDistribution { get; set; } = new();
    }
}
