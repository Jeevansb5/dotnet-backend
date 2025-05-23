using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OracleJwtApiFull.DTOs;
using OracleJwtApiFull.Services.Interfaces;
using System.Threading.Tasks;

namespace OracleJwtApiFull.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AirportController : ControllerBase
    {
        private readonly IAirportService _service;
        private readonly ILogger<AirportController> _logger;

        public AirportController(IAirportService service, ILogger<AirportController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var airports = await _service.GetAllAsync();
            return Ok(airports);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var airport = await _service.GetByIdAsync(id);
            return airport is null ? NotFound() : Ok(airport);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAirportDto dto)
        {
            if (ModelState.IsValid is false)
                return BadRequest(ModelState);

            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateAirportDto dto)
        {
            if (ModelState.IsValid is false)
                return BadRequest(ModelState);

            var success = await _service.UpdateAsync(id, dto);
            return success ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Cancel(int id)
        {
            var success = await _service.CancelAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}