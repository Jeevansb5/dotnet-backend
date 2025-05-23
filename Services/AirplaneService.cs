using Microsoft.EntityFrameworkCore;
using OracleJwtApiFull.Data;
using OracleJwtApiFull.Models;
using OracleJwtApiFull.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OracleJwtApiFull.Services
{
    public class AirplaneService : IAirplaneService
    {
        private readonly ApplicationDbContext _context;

        public AirplaneService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Airplane>> GetAllAsync()
        {
            return await _context.Airplanes.ToListAsync();
        }

        public async Task<Airplane> GetByIdAsync(int id)
        {
            return await _context.Airplanes.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Airplane> AddAsync(Airplane airplane)
        {
            airplane.CreatedAt = DateTime.UtcNow;
            _context.Airplanes.Add(airplane);
            await _context.SaveChangesAsync();
            return airplane;
        }

        public async Task<Airplane> UpdateAsync(int id, Airplane updatedAirplane)
        {
            var airplane = await _context.Airplanes.FindAsync(id);
            if (airplane == null) return null;

            airplane.Model = updatedAirplane.Model;
            airplane.EconomyCapacity = updatedAirplane.EconomyCapacity;
            airplane.BusinessCapacity = updatedAirplane.BusinessCapacity;
            airplane.FirstClassCapacity = updatedAirplane.FirstClassCapacity;
            airplane.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return airplane;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var airplane = await _context.Airplanes.FindAsync(id);
            if (airplane == null) return false;

            _context.Airplanes.Remove(airplane);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
