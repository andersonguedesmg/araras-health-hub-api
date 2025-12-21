using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Dashboards.Queries.GetSummary;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace araras_health_hub_api.Controllers
{
    [Route("api/dashboard")]
    [ApiController]
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IMediator _mediator;

        public DashboardController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("summary")]
        [Authorize(Policy = "CanReadManagementResource")]
        public async Task<IActionResult> GetSummary([FromQuery] GetDashboardSummaryQuery query)
        {
            var result = await _mediator.Send(query);
            return StatusCode(result.StatusCode, result);
        }
    }
}
