using OracleJwtApiFull.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OracleJwtApiFull.Repositories.Interfaces
{
    public interface IAirportRepository
    {
        Task<IEnumerable<Airport>> GetAllAsync();
        Task<Airport?> GetByIdAsync(int id);
        Task<Airport> AddAsync(Airport airport);
        Task<bool> UpdateAsync(Airport airport);
        Task<bool> CancelAsync(int id);
    }
}