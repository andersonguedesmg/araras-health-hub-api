using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using araras_health_hub_api.Data;
using araras_health_hub_api.Dtos.DestinationUser;
using araras_health_hub_api.Interfaces;
using araras_health_hub_api.Models;
using Microsoft.EntityFrameworkCore;

namespace araras_health_hub_api.Repository
{
    public class DestinationUserRepository : IDestinationUserRepository
    {
        private readonly ApplicationDBContext _context;

        public DestinationUserRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<DestinationUser> CreateAsync(DestinationUser destinationUserModel)
        {
            await _context.DestinationUser.AddAsync(destinationUserModel);
            await _context.SaveChangesAsync();
            return destinationUserModel;
        }

        public async Task<DestinationUser?> DeleteAsync(int id)
        {
            var destinationUserModel = await _context.DestinationUser.FirstOrDefaultAsync(x => x.Id == id);

            if (destinationUserModel == null)
            {
                return null;
            }

            _context.DestinationUser.Remove(destinationUserModel);
            await _context.SaveChangesAsync();
            return destinationUserModel;
        }

        public async Task<List<DestinationUser>> GetAllAsync()
        {
            return await _context.DestinationUser.ToListAsync();
        }

        public async Task<DestinationUser?> GetByIdAsync(int id)
        {
            return await _context.DestinationUser.FindAsync(id);
        }

        public async Task<DestinationUser?> UpdateAsync(int id, DestinationUser destinationUserModel)
        {
            var existingDestinationUser = await _context.DestinationUser.FindAsync(id);

            if (existingDestinationUser == null)
            {
                return null;
            }

            existingDestinationUser.Name = destinationUserModel.Name;
            existingDestinationUser.Password = destinationUserModel.Password;
            existingDestinationUser.Role = destinationUserModel.Role;
            existingDestinationUser.UpdatedOn = destinationUserModel.UpdatedOn;
            existingDestinationUser.IsActive = destinationUserModel.IsActive;

            await _context.SaveChangesAsync();
            return existingDestinationUser;
        }
    }
}
