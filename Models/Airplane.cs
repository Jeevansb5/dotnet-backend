using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OracleJwtApiFull.Models
{
    public class Airplane
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Model { get; set; }

        [Range(0, 1000)]
        public int EconomyCapacity { get; set; }

        [Range(0, 500)]
        public int BusinessCapacity { get; set; }

        [Range(0, 100)]
        public int FirstClassCapacity { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }

}
