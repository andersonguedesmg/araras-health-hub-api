using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Orders.Dtos;

namespace ArarasHealthHub.Application.Interfaces.Services
{
    public interface IPdfService
    {
        Task<byte[]> GeneratePickingListAsync(OrderDto order);
    }
}
