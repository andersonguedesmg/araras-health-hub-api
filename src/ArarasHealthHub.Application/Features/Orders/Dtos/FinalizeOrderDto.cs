using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Features.Orders.Dtos
{
    public class FinalizeOrderDto
    {
        public int OrderId { get; set; }
        public int FinalizedByEmployeeId { get; set; }
        public int FinalizedByAccountId { get; set; }
    }
}
