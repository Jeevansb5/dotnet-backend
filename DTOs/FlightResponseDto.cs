using System;

namespace OracleJwtApiFull.DTOs
{
    public class FlightResponseDto
    {
        public int FlightId { get; set; }
        public string FlightNumber { get; set; }
        public int AirplaneId { get; set; }
        public int OriginAirportId { get; set; }
        public int DestinationAirportId { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string Duration { get; set; }
        public int AvailableEconomySeats { get; set; }
        public int AvailableBusinessSeats { get; set; }
        public int AvailableFirstClassSeats { get; set; }

        // 🎯 Prices by Class
        public decimal EconomyPrice { get; set; }
        public decimal BusinessPrice { get; set; }
        public decimal FirstClassPrice { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
