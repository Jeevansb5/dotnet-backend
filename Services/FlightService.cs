using AutoMapper;
using OracleJwtApiFull.DTOs;
using OracleJwtApiFull.Models;
using OracleJwtApiFull.Repositories.Interfaces;
using OracleJwtApiFull.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OracleJwtApiFull.Services
{
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository _flightRepository;
        private readonly IMapper _mapper;

        public FlightService(IFlightRepository flightRepository, IMapper mapper)
        {
            _flightRepository = flightRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FlightResponseDto>> GetAllFlightsAsync()
        {
            var flights = await _flightRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<FlightResponseDto>>(flights);
        }

        public async Task<FlightResponseDto> GetFlightByIdAsync(int id)
        {
            var flight = await _flightRepository.GetByIdAsync(id);
            return _mapper.Map<FlightResponseDto>(flight);
        }

        public async Task<bool> CreateFlightAsync(FlightCreateDto dto)
        {
            var flight = _mapper.Map<Flight>(dto);

            // Automatically calculate duration
            flight.Duration = (flight.ArrivalTime - flight.DepartureTime).ToString(@"hh\:mm");

            // Set creation timestamp
            flight.CreatedAt = DateTime.UtcNow;

            // Assign prices
            flight.EconomyPrice = dto.EconomyPrice;
            flight.BusinessPrice = dto.BusinessPrice;
            flight.FirstClassPrice = dto.FirstClassPrice;

            await _flightRepository.AddAsync(flight);
            return true;
        }

        public async Task<bool> UpdateFlightAsync(int id, FlightCreateDto dto)
        {
            var flight = await _flightRepository.GetByIdAsync(id);
            if (flight == null)
                return false;

            // Update fields
            flight.FlightNumber = dto.FlightNumber;
            flight.AirplaneId = dto.AirplaneId;
            flight.OriginAirportId = dto.OriginAirportId;
            flight.DestinationAirportId = dto.DestinationAirportId;
            flight.DepartureTime = dto.DepartureTime;
            flight.ArrivalTime = dto.ArrivalTime;
            flight.Duration = (dto.ArrivalTime - dto.DepartureTime).ToString(@"hh\:mm");
            flight.AvailableEconomySeats = dto.AvailableEconomySeats;
            flight.AvailableBusinessSeats = dto.AvailableBusinessSeats;
            flight.AvailableFirstClassSeats = dto.AvailableFirstClassSeats;

            // Update prices
            flight.EconomyPrice = dto.EconomyPrice;
            flight.BusinessPrice = dto.BusinessPrice;
            flight.FirstClassPrice = dto.FirstClassPrice;

            flight.UpdatedAt = DateTime.UtcNow;

            await _flightRepository.UpdateAsync(flight);
            return true;
        }

        public async Task<bool> DeleteFlightAsync(int id)
        {
            var flight = await _flightRepository.GetByIdAsync(id);
            if (flight == null)
                return false;

            await _flightRepository.DeleteAsync(flight);
            return true;
        }
    }
}
