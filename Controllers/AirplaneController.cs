using Microsoft.AspNetCore.Mvc;
using OracleJwtApiFull.DTOs;
using OracleJwtApiFull.Models;
using OracleJwtApiFull.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OracleJwtApiFull.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AirplaneController : ControllerBase
    {
        private readonly IAirplaneService _airplaneService;

        public AirplaneController(IAirplaneService airplaneService)
        {
            _airplaneService = airplaneService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AirplaneReadDto>>> GetAll()
        {
            var airplanes = await _airplaneService.GetAllAsync();
            var dtoList = airplanes.Select(a => new AirplaneReadDto
            {
                Id = a.Id,
                Model = a.Model,
                EconomyCapacity = a.EconomyCapacity,
                BusinessCapacity = a.BusinessCapacity,
                FirstClassCapacity = a.FirstClassCapacity,
                CreatedAt = a.CreatedAt,
                UpdatedAt = a.UpdatedAt
            });

            return Ok(dtoList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AirplaneReadDto>> GetById(int id)
        {
            var airplane = await _airplaneService.GetByIdAsync(id);
            if (airplane == null) return NotFound();

            var dto = new AirplaneReadDto
            {
                Id = airplane.Id,
                Model = airplane.Model,
                EconomyCapacity = airplane.EconomyCapacity,
                BusinessCapacity = airplane.BusinessCapacity,
                FirstClassCapacity = airplane.FirstClassCapacity,
                CreatedAt = airplane.CreatedAt,
                UpdatedAt = airplane.UpdatedAt
            };

            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<AirplaneReadDto>> CreateAirplane([FromBody] AirplaneCreateDto dto)
        {
            var airplane = new Airplane
            {
                Model = dto.Model,
                EconomyCapacity = dto.EconomyCapacity,
                BusinessCapacity = dto.BusinessCapacity,
                FirstClassCapacity = dto.FirstClassCapacity,
                CreatedAt = DateTime.UtcNow
            };

            var created = await _airplaneService.AddAsync(airplane);

            var readDto = new AirplaneReadDto
            {
                Id = created.Id,
                Model = created.Model,
                EconomyCapacity = created.EconomyCapacity,
                BusinessCapacity = created.BusinessCapacity,
                FirstClassCapacity = created.FirstClassCapacity,
                CreatedAt = created.CreatedAt,
                UpdatedAt = created.UpdatedAt
            };

            return CreatedAtAction(nameof(GetById), new { id = readDto.Id }, readDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AirplaneReadDto>> Update(int id, [FromBody] AirplaneUpdateDto dto)
        {
            var airplane = new Airplane
            {
                Model = dto.Model,
                EconomyCapacity = dto.EconomyCapacity,
                BusinessCapacity = dto.BusinessCapacity,
                FirstClassCapacity = dto.FirstClassCapacity,
                UpdatedAt = DateTime.UtcNow
            };

            var result = await _airplaneService.UpdateAsync(id, airplane);
            if (result == null) return NotFound();

            var readDto = new AirplaneReadDto
            {
                Id = result.Id,
                Model = result.Model,
                EconomyCapacity = result.EconomyCapacity,
                BusinessCapacity = result.BusinessCapacity,
                FirstClassCapacity = result.FirstClassCapacity,
                CreatedAt = result.CreatedAt,
                UpdatedAt = result.UpdatedAt
            };

            return Ok(readDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _airplaneService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
