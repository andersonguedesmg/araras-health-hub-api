using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Features.Stocks.Commands.UpdateMinQuantity
{
    public class UpdateMinQuantityRequest
    {
        public decimal NewMinQuantity { get; set; }
    }
}
