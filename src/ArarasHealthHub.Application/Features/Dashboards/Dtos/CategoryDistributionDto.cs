using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Features.Dashboards.Dtos
{
    public class CategoryDistributionDto
    {
        public string Category { get; set; } = string.Empty;
        public int Value { get; set; }
    }
}
