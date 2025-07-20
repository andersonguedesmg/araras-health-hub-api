using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Domain.Entities
{
    public class OrderStatus
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
