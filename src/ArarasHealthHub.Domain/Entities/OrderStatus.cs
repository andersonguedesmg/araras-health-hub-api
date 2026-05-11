using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Exceptions;

namespace ArarasHealthHub.Domain.Entities
{
    public class OrderStatus : BaseEntity
    {
        public string Description { get; private set; } = string.Empty;

        private OrderStatus() { }

        public OrderStatus(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new DomainException(
                    "Descrição do status é obrigatória."
                );

            Description = description.Trim();
        }
    }
}
