using System;

namespace OracleJwtApiFull.DTOs
{
    public class AirplaneCreateDto
    {
        public string Model { get; set; }
        public int EconomyCapacity { get; set; }
        public int BusinessCapacity { get; set; }
        public int FirstClassCapacity { get; set; }
    }

    public class AirplaneUpdateDto
    {
        public string Model { get; set; }
        public int EconomyCapacity { get; set; }
        public int BusinessCapacity { get; set; }
        public int FirstClassCapacity { get; set; }
    }

    public class AirplaneReadDto
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int EconomyCapacity { get; set; }
        public int BusinessCapacity { get; set; }
        public int FirstClassCapacity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
