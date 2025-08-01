using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Features.Orders.Dtos
{
    public class ApproveOrderDto
    {
        public int OrderId { get; set; }
        public int ApprovedByEmployeeId { get; set; }
        public int ApprovedByAccountId { get; set; }
        public List<ApproveOrderItemDto> OrderItems { get; set; } = new();
    }
}
