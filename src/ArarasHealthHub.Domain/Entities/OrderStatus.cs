using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Domain.Entities
{
    public class OrderStatus : BaseEntity
    {
        public string Description { get; private set; } = string.Empty;

        private OrderStatus() { }

        public OrderStatus(string description)
        {
            Description = description;
        }
    }
}
