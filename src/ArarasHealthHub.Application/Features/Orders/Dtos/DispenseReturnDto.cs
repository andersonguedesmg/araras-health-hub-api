using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Features.Orders.Dtos
{
    public class DispenseReturnDto
    {
        public int OriginalOrderId { get; set; }
        public int ReturnedByEmployeeId { get; set; }
        public int ReturnedByAccountId { get; set; }
        public string Reason { get; set; } = string.Empty;
        public List<DispenseReturnItemDto> ReturnItems { get; set; } = new();
    }
}
