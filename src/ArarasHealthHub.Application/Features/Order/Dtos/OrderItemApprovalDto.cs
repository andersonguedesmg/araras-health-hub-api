using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Features.Order.Dtos
{
    public class OrderItemApprovalDto
    {
        [Required]
        public int OrderItemId { get; set; }

        [Required]
        public int ApprovedQuantity { get; set; }
    }
}
