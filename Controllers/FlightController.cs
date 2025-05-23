using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OracleJwtApiFull.DTOs;
using OracleJwtApiFull.Services.Interfaces;
using System.Threading.Tasks;

namespace OracleJwtApiFull.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightController : ControllerBase
    {
        private readonly IFlightService _flightService;

        public FlightController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var flights = await _flightService.GetAllFlightsAsync();
            return Ok(flights);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var flight = await _flightService.GetFlightByIdAsync(id);
            if (flight == null)
                return NotFound();

            return Ok(flight);
        }

        [HttpPost]
        public async Task<IActionResult> Create(FlightCreateDto dto)
        {
            var result = await _flightService.CreateFlightAsync(dto);
            if (!result)
                return BadRequest("Could not create flight.");

            return Ok("Flight created successfully.");
        }

    
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, FlightCreateDto dto)
        {
            var result = await _flightService.UpdateFlightAsync(id, dto);
            if (!result)
                return NotFound("Flight not found.");

            return Ok("Flight updated successfully.");
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _flightService.DeleteFlightAsync(id);
            if (!result)
                return NotFound("Flight not found.");

            return Ok("Flight deleted successfully.");
        }
    }
}
