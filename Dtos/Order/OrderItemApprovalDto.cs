using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace araras_health_hub_api.Dtos.Order
{
    public class OrderItemApprovalDto
    {
        [Required]
        public int OrderItemId { get; set; }

        [Required]
        public int ApprovedQuantity { get; set; }
    }
}
