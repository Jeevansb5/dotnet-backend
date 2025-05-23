using OracleJwtApiFull.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OracleJwtApiFull.Services.Interfaces
{
    public interface IAirplaneService
    {
        Task<List<Airplane>> GetAllAsync();
        Task<Airplane> GetByIdAsync(int id);
        Task<Airplane> AddAsync(Airplane airplane);
        Task<Airplane> UpdateAsync(int id, Airplane airplane);
        Task<bool> DeleteAsync(int id);
    }
}
