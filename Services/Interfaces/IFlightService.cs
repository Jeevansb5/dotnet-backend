using OracleJwtApiFull.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OracleJwtApiFull.Services.Interfaces
{
    public interface IFlightService
    {
        Task<IEnumerable<FlightResponseDto>> GetAllFlightsAsync();
        Task<FlightResponseDto> GetFlightByIdAsync(int id);
        Task<bool> CreateFlightAsync(FlightCreateDto dto);
        Task<bool> UpdateFlightAsync(int id, FlightCreateDto dto);
        Task<bool> DeleteFlightAsync(int id);
    }
}
