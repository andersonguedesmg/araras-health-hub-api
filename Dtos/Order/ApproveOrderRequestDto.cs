using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace araras_health_hub_api.Dtos.Order
{
    public class ApproveOrderRequestDto
    {
        [Required]
        public int OrderId { get; set; }

        [Required]
        public int ApprovedByEmployeeId { get; set; }

        [Required]
        public int ApprovedByAccountId { get; set; }

        public int OrderStatusId { get; set; }

        [Required]
        public List<OrderItemApprovalDto> OrderItemsApproval { get; set; } = new();
    }
}
