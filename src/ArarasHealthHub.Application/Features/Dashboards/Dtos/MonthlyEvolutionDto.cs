using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Features.Dashboards.Dtos
{
    public class MonthlyEvolutionDto
    {
        public string Month { get; set; } = string.Empty;
        public int Count { get; set; }
    }
}
