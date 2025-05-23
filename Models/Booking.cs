using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OracleJwtApiFull.Models
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingId { get; set; }

        [Required]
        public int UserId { get; set; }  // Foreign key to User

        [Required]
        public int FlightId { get; set; }  // Foreign key to Flight

        [Required]
        public int NumberOfSeats { get; set; }
        
        [Required]
        public decimal TotalPrice { get; set; }  // Total price for the booking

        [Required]
        [MaxLength(20)]
        public string SeatClass { get; set; }  // e.g., Economy, Business, First

        [Required]
        public DateTime BookingDate { get; set; } = DateTime.UtcNow;

        public DateTime? CancelledAt { get; set; }

        public ICollection<Passenger> Passengers { get; set; }

        // Navigation properties
        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("FlightId")]
        public Flight Flight { get; set; }
    }
}
