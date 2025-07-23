using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Facility.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Infrastructure.Repository
{
    public class FacilityRepository : IFacilityRepository
    {
        private readonly ApplicationDBContext _context;

        public FacilityRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Facility?> ChangeStatusAsync(int id, ChangeStatusFacilityRequestDto facilityDto)
        {
            var existingFacility = await _context.Facility.FirstOrDefaultAsync(d => d.Id == id);

            if (existingFacility == null)
            {
                return null;
            }

            existingFacility.IsActive = facilityDto.IsActive;
            existingFacility.UpdatedOn = DateTime.Now;

            await _context.SaveChangesAsync();

            return existingFacility;
        }

        public async Task<Facility> CreateAsync(Facility facilityModel)
        {
            await _context.Facility.AddAsync(facilityModel);
            await _context.SaveChangesAsync();
            return facilityModel;
        }

        public async Task<Facility?> DeleteAsync(int id)
        {
            var facilityModel = await _context.Facility.FirstOrDefaultAsync(d => d.Id == id);

            if (facilityModel == null)
            {
                return null;
            }

            _context.Facility.Remove(facilityModel);
            await _context.SaveChangesAsync();
            return facilityModel;
        }

        public Task<bool> FacilityExists(int id)
        {
            return _context.Facility.AnyAsync(s => s.Id == id);
        }

        public async Task<List<Facility>> GetAllAsync()
        {
            // return await _context.Facility.Include(u => u.AccountUsers).ToListAsync();
            return await _context.Facility.ToListAsync();
        }

        public async Task<Facility?> GetByIdAsync(int id)
        {
            // return await _context.Facility.Include(u => u.AccountUsers).FirstOrDefaultAsync(i => i.Id == id);
            return await _context.Facility.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Facility?> UpdateAsync(int id, UpdateFacilityRequestDto facilityDto)
        {
            var existingFacility = await _context.Facility.FirstOrDefaultAsync(d => d.Id == id);

            if (existingFacility == null)
            {
                return null;
            }

            existingFacility.Name = facilityDto.Name;
            existingFacility.Address = facilityDto.Address;
            existingFacility.Number = facilityDto.Number;
            existingFacility.Neighborhood = facilityDto.Neighborhood;
            existingFacility.City = facilityDto.City;
            existingFacility.State = facilityDto.State;
            existingFacility.Cep = facilityDto.Cep;
            existingFacility.Email = facilityDto.Email;
            existingFacility.Phone = facilityDto.Phone;
            existingFacility.UpdatedOn = DateTime.Now;
            existingFacility.IsActive = facilityDto.IsActive;

            await _context.SaveChangesAsync();

            return existingFacility;
        }
    }
}
