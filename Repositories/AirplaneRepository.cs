using Microsoft.EntityFrameworkCore;
using OracleJwtApiFull.Data;
using OracleJwtApiFull.Models;
using OracleJwtApiFull.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OracleJwtApiFull.Repositories
{
    public class AirplaneRepository : IAirplaneRepository
    {
        private readonly ApplicationDbContext _context;

        public AirplaneRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Airplane>> GetAllAsync()
        {
            return await _context.Airplanes.ToListAsync();
        }

        public async Task<Airplane> GetByIdAsync(int id)
        {
            return await _context.Airplanes.FindAsync(id);
        }

        public async Task<Airplane> AddAsync(Airplane airplane)
        {
            _context.Airplanes.Add(airplane);
            await _context.SaveChangesAsync();
            return airplane;
        }

        public async Task<Airplane> UpdateAsync(Airplane airplane)
        {
            _context.Airplanes.Update(airplane);
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
