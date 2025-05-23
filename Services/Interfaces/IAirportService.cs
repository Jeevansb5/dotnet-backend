using OracleJwtApiFull.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OracleJwtApiFull.Services.Interfaces
{
    public interface IAirportService
    {
        Task<IEnumerable<AirportDto>> GetAllAsync();
        Task<AirportDto?> GetByIdAsync(int id);
        Task<AirportDto> CreateAsync(CreateAirportDto dto);
        Task<bool> UpdateAsync(int id, CreateAirportDto dto);
        Task<bool> CancelAsync(int id);
    }
}