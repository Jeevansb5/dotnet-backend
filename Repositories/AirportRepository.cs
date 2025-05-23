using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OracleJwtApiFull.Data;
using OracleJwtApiFull.Models;
using OracleJwtApiFull.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;



namespace OracleJwtApiFull.Repositories
{
    public class AirportRepository : IAirportRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<AirportRepository> _logger;

        public AirportRepository(ApplicationDbContext context, ILogger<AirportRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Airport>> GetAllAsync()
        {
            return await _context.Airports.Where(a => a.IsActive).ToListAsync();
        }

        public async Task<Airport?> GetByIdAsync(int id)
        {
            return await _context.Airports.FirstOrDefaultAsync(a => a.Id == id && a.IsActive);
        }

        public async Task<Airport> AddAsync(Airport airport)
        {
            _context.Airports.Add(airport);
            await _context.SaveChangesAsync();
            return airport;
        }

        public async Task<bool> UpdateAsync(Airport airport)
        {
            var existing = await _context.Airports.FindAsync(airport.Id);
            if (existing is null || existing.IsActive is false)
                return false;

            existing.Name = airport.Name;
            existing.Code = airport.Code;
            existing.City = airport.City;
            existing.Country = airport.Country;
            existing.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CancelAsync(int id)
        {
            var airport = await _context.Airports.FindAsync(id);
            if (airport is null || airport.IsActive is false)
                return false;

            airport.IsActive = false;
            airport.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}