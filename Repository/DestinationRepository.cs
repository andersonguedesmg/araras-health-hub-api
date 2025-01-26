using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using araras_health_hub_api.Data;
using araras_health_hub_api.Dtos.Destination;
using araras_health_hub_api.Interfaces;
using araras_health_hub_api.Models;
using Microsoft.EntityFrameworkCore;

namespace araras_health_hub_api.Repository
{
    public class DestinationRepository : IDestinationRepository
    {
        private readonly ApplicationDBContext _context;

        public DestinationRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Destination> CreateAsync(Destination destinationModel)
        {
            await _context.Destination.AddAsync(destinationModel);
            await _context.SaveChangesAsync();
            return destinationModel;
        }

        public async Task<Destination?> DeleteAsync(int id)
        {
            var destinationModel = await _context.Destination.FirstOrDefaultAsync(d => d.Id == id);

            if (destinationModel == null)
            {
                return null;
            }

            _context.Destination.Remove(destinationModel);
            await _context.SaveChangesAsync();
            return destinationModel;
        }

        public async Task<List<Destination>> GetAllAsync()
        {
            return await _context.Destination.ToListAsync();
        }

        public async Task<Destination?> GetByIdAsync(int id)
        {
            return await _context.Destination.FindAsync(id);
        }

        public async Task<Destination?> UpdateAsync(int id, UpdateDestinationRequestDto destinationDto)
        {
            var existingDestination = await _context.Destination.FirstOrDefaultAsync(d => d.Id == id);

            if (existingDestination == null)
            {
                return null;
            }

            existingDestination.Name = destinationDto.Name;
            existingDestination.Address = destinationDto.Address;
            existingDestination.Number = destinationDto.Number;
            existingDestination.Neighborhood = destinationDto.Neighborhood;
            existingDestination.City = destinationDto.City;
            existingDestination.State = destinationDto.State;
            existingDestination.Cep = destinationDto.Cep;
            existingDestination.Email = destinationDto.Email;
            existingDestination.Phone = destinationDto.Phone;
            existingDestination.UpdatedOn = destinationDto.UpdatedOn;
            existingDestination.IsActive = destinationDto.IsActive;

            await _context.SaveChangesAsync();

            return existingDestination;
        }
    }
}
