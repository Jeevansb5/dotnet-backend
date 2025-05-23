using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OracleJwtApiFull.Models
{
    public class Flight
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FlightId { get; set; }

        [Required]
        [MaxLength(10)]
        public string FlightNumber { get; set; }

        // Foreign key to Airplane
        [Required]
        public int AirplaneId { get; set; }

        [ForeignKey("AirplaneId")]
        public Airplane Airplane { get; set; }

        // Foreign key to Airport (Origin)
        [Required]
        public int OriginAirportId { get; set; }

        [ForeignKey("OriginAirportId")]
        public Airport OriginAirport { get; set; }

        // Foreign key to Airport (Destination)
        [Required]
        public int DestinationAirportId { get; set; }

        [ForeignKey("DestinationAirportId")]
        public Airport DestinationAirport { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; }

        [Required]
        public DateTime ArrivalTime { get; set; }

        [MaxLength(20)]
        public string Duration { get; set; }

        // 🎯 Seat Availability by Class
        [Required]
        public int AvailableEconomySeats { get; set; }

        [Required]
        public int AvailableBusinessSeats { get; set; }

        [Required]
        public int AvailableFirstClassSeats { get; set; }

        // 💰 Prices by Class
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal EconomyPrice { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal BusinessPrice { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal FirstClassPrice { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
