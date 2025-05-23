using System.ComponentModel.DataAnnotations;

namespace OracleJwtApiFull.DTOs
{
    public class AirportDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
    }

    public class CreateAirportDto
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Code is required")]
        [MaxLength(3)]
        public string Code { get; set; } = string.Empty;

        [Required(ErrorMessage = "City is required")]
        [MaxLength(100)]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Country is required")]
        [MaxLength(100)]
        public string Country { get; set; } = string.Empty;
    }
}