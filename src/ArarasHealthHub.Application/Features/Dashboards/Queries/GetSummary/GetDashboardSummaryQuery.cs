using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Dashboards.Dtos;
using ArarasHealthHub.Shared.Core;
using MediatR;

namespace ArarasHealthHub.Application.Features.Dashboards.Queries.GetSummary
{
    public class GetDashboardSummaryQuery : IRequest<ApiResponse<DashboardSummaryDto>>
    {

    }
}
