using OracleJwtApiFull.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OracleJwtApiFull.Repositories.Interfaces
{
    public interface IAirplaneRepository
    {
        Task<List<Airplane>> GetAllAsync();
        Task<Airplane> GetByIdAsync(int id);
        Task<Airplane> AddAsync(Airplane airplane);
        Task<Airplane> UpdateAsync(Airplane airplane);
        Task<bool> DeleteAsync(int id);
    }
}
