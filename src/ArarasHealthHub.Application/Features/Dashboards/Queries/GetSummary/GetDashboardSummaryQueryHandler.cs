using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Dashboards.Dtos;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Shared.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Dashboards.Queries.GetSummary
{
    public class GetDashboardSummaryQueryHandler : IRequestHandler<GetDashboardSummaryQuery, ApiResponse<DashboardSummaryDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetDashboardSummaryQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse<DashboardSummaryDto>> Handle(GetDashboardSummaryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var summary = new DashboardSummaryDto();
                summary.PendingApprovalCount = await _context.Orders
                    .CountAsync(x => x.OrderStatusId == (int)OrderStatusEnum.PendingApproval, cancellationToken);

                summary.PendingSeparationCount = await _context.Orders
                    .CountAsync(x => x.OrderStatusId == (int)OrderStatusEnum.ReadyForPicking ||
                                     x.OrderStatusId == (int)OrderStatusEnum.PickingInProgress, cancellationToken);

                summary.PendingDeliveryCount = await _context.Orders
                    .CountAsync(x => x.OrderStatusId == (int)OrderStatusEnum.ReadyForFinalization, cancellationToken);

                summary.CriticalStockCount = await _context.Stocks
                    .CountAsync(x => x.AvailableQuantity <= x.MinQuantity, cancellationToken);

                summary.TotalActiveProducts = await _context.Products.CountAsync(cancellationToken);

                // Evolução Mensal (Últimos 6 meses)
                var sixMonthsAgo = DateTime.Now.AddMonths(-5);
                var monthlyData = await _context.Orders
                    .Where(o => o.CreatedAt >= new DateTime(sixMonthsAgo.Year, sixMonthsAgo.Month, 1))
                    .GroupBy(o => new { o.CreatedAt.Year, o.CreatedAt.Month })
                    .Select(g => new { g.Key.Year, g.Key.Month, Count = g.Count() })
                    .OrderBy(g => g.Year).ThenBy(g => g.Month)
                    .ToListAsync(cancellationToken);

                summary.MonthlyEvolution = monthlyData.Select(x => new MonthlyEvolutionDto
                {
                    Month = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(x.Month).ToUpper(),
                    Count = x.Count
                }).ToList();

                summary.CategoryDistribution = await _context.Products
                    .GroupBy(p => p.MainCategory)
                    .Select(g => new CategoryDistributionDto
                    {
                        Category = g.Key,
                        Value = g.Count()
                    })
                    .OrderByDescending(x => x.Value)
                    .Take(5)
                    .ToListAsync(cancellationToken);

                return new ApiResponse<DashboardSummaryDto>(200, "Dashboard carregado com sucesso", summary);
            }
            catch (Exception ex)
            {
                return new ApiResponse<DashboardSummaryDto>(500, $"Erro ao processar dashboard: {ex.Message}", false);
            }
        }
    }
}
