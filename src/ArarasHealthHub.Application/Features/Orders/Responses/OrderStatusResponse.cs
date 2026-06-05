using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Features.Orders.Responses
{
    public sealed record OrderStatusResponse(
        int Id,
        string Description
    );
}
