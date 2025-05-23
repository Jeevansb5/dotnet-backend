using AutoMapper;
using OracleJwtApiFull.DTOs;
using OracleJwtApiFull.Models;


namespace OracleJwtApiFull.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FlightCreateDto, Flight>();
            CreateMap<Flight, FlightResponseDto>();
        }
    }
}
