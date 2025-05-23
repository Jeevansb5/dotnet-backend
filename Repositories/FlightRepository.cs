using Microsoft.EntityFrameworkCore;
using OracleJwtApiFull.Data;
using OracleJwtApiFull.Models;
using OracleJwtApiFull.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OracleJwtApiFull.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly ApplicationDbContext _context;

        public FlightRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Flight>> GetAllAsync()
        {
            return await _context.Flights
                .Include(f => f.Airplane)
                .Include(f => f.OriginAirport)
                .Include(f => f.DestinationAirport)
                .ToListAsync();
        }

        public async Task<Flight> GetByIdAsync(int id)
        {
            return await _context.Flights
                .Include(f => f.Airplane)
                .Include(f => f.OriginAirport)
                .Include(f => f.DestinationAirport)
                .FirstOrDefaultAsync(f => f.FlightId == id);
        }

        public async Task AddAsync(Flight flight)
        {
            await _context.Flights.AddAsync(flight);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Flight flight)
        {
            _context.Flights.Update(flight);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Flight flight)
        {
            _context.Flights.Remove(flight);
            await _context.SaveChangesAsync();
        }
    }
}
