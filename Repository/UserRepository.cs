using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using araras_health_hub_api.Data;
using araras_health_hub_api.Dtos.User;
using araras_health_hub_api.Interfaces;
using araras_health_hub_api.Models;
using Microsoft.EntityFrameworkCore;

namespace araras_health_hub_api.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;

        public UserRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<User?> ChangeStatusAsync(int id, ChangeStatusUserRequestDto userDto)
        {
            var existingUser = await _context.User.FirstOrDefaultAsync(u => u.Id == id);

            if (existingUser == null)
            {
                return null;
            }

            existingUser.IsActive = userDto.IsActive;
            existingUser.UpdatedOn = DateTime.Now;

            await _context.SaveChangesAsync();

            return existingUser;
        }

        public async Task<User> CreateAsync(User userModel)
        {
            await _context.User.AddAsync(userModel);
            await _context.SaveChangesAsync();
            return userModel;
        }

        public async Task<User?> DeleteAsync(int id)
        {
            var userModel = await _context.User.FirstOrDefaultAsync(u => u.Id == id);

            if (userModel == null)
            {
                return null;
            }

            _context.User.Remove(userModel);
            await _context.SaveChangesAsync();
            return userModel;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.User.FindAsync(id);
        }

        public async Task<User?> UpdateAsync(int id, UpdateUserRequestDto userDto)
        {
            var existingUser = await _context.User.FirstOrDefaultAsync(d => d.Id == id);

            if (existingUser == null)
            {
                return null;
            }

            existingUser.Name = userDto.Name;
            existingUser.Function = userDto.Function;
            existingUser.Phone = userDto.Phone;
            existingUser.UpdatedOn = DateTime.Now;
            existingUser.IsActive = userDto.IsActive;

            await _context.SaveChangesAsync();

            return existingUser;
        }
    }
}
