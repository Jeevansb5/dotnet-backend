using OracleJwtApiFull.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OracleJwtApiFull.Repositories.Interfaces
{
    public interface IFlightRepository
    {
        Task<IEnumerable<Flight>> GetAllAsync();
        Task<Flight> GetByIdAsync(int id);
        Task AddAsync(Flight flight);
        Task UpdateAsync(Flight flight);
        Task DeleteAsync(Flight flight);
    }
}
