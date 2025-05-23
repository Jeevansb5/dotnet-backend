using Microsoft.Extensions.Logging;
using OracleJwtApiFull.DTOs;
using OracleJwtApiFull.Models;
using OracleJwtApiFull.Repositories.Interfaces;
using OracleJwtApiFull.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OracleJwtApiFull.Services
{
    public class AirportService : IAirportService
    {
        private readonly IAirportRepository _repository;
        private readonly ILogger<AirportService> _logger;

        public AirportService(IAirportRepository repository, ILogger<AirportService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<AirportDto>> GetAllAsync()
        {
            var airports = await _repository.GetAllAsync();
            return airports.Select(a => new AirportDto
            {
                Id = a.Id,
                Name = a.Name,
                Code = a.Code,
                City = a.City,
                Country = a.Country
            });
        }

        public async Task<AirportDto?> GetByIdAsync(int id)
        {
            var airport = await _repository.GetByIdAsync(id);
            return airport is null ? null : new AirportDto
            {
                Id = airport.Id,
                Name = airport.Name,
                Code = airport.Code,
                City = airport.City,
                Country = airport.Country
            };
        }

        public async Task<AirportDto> CreateAsync(CreateAirportDto dto)
        {
            var airport = new Airport
            {
                Name = dto.Name,
                Code = dto.Code,
                City = dto.City,
                Country = dto.Country
            };

            var result = await _repository.AddAsync(airport);
            return new AirportDto
            {
                Id = result.Id,
                Name = result.Name,
                Code = result.Code,
                City = result.City,
                Country = result.Country
            };
        }

        public async Task<bool> UpdateAsync(int id, CreateAirportDto dto)
        {
            var airport = new Airport
            {
                Id = id,
                Name = dto.Name,
                Code = dto.Code,
                City = dto.City,
                Country = dto.Country
            };

            return await _repository.UpdateAsync(airport);
        }

        public async Task<bool> CancelAsync(int id)
        {
            return await _repository.CancelAsync(id);
        }
    }
}
