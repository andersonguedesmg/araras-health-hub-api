using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Domain.Entities;

namespace ArarasHealthHub.Application.Interfaces.Repositories
{
    public interface IReceivingRepository
    {
        Task<Receiving> CreateAsync(Receiving receiving);
        Task<Receiving?> GetByIdAsync(int id);
        Task<List<Receiving>> GetAllAsync();
        Task<ReceivingItem> CreateReceivingItemAsync(ReceivingItem receivingItem);
    }
}
