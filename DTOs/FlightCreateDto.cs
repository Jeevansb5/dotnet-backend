using System;
using System.ComponentModel.DataAnnotations;

namespace OracleJwtApiFull.DTOs
{
    public class FlightCreateDto
    {
        [Required]
        [MaxLength(10)]
        public string FlightNumber { get; set; }

        [Required]
        public int AirplaneId { get; set; }

        [Required]
        public int OriginAirportId { get; set; }

        [Required]
        public int DestinationAirportId { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; }

        [Required]
        public DateTime ArrivalTime { get; set; }

        [Required]
        public int AvailableEconomySeats { get; set; }

        [Required]
        public int AvailableBusinessSeats { get; set; }

        [Required]
        public int AvailableFirstClassSeats { get; set; }

        // 🎯 Prices by Class
        [Required]
        public decimal EconomyPrice { get; set; }

        [Required]
        public decimal BusinessPrice { get; set; }

        [Required]
        public decimal FirstClassPrice { get; set; }
    }
}
