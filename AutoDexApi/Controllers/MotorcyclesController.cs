
using Microsoft.AspNetCore.Mvc;
using AutoDexApi.DB;
using AutoDexApi.Models;
using AutoDexApi.Dtos;
using AutoDexApi.Dtos.MotorcycleDtos;
using Microsoft.EntityFrameworkCore;

namespace AutoDexApi.Controllers
{
    [ApiController]
    [Route("Motorcycles")]
    public class MotorcyclesController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public MotorcyclesController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddMotorcycle(MotorcycleCreateDto MotorcycleDto)
        {
            if (MotorcycleDto == null)
            {
                return BadRequest("invalid data");
            }

            var Motorcycle = new Motorcycle()
            {
                Name = MotorcycleDto.Name,
                Mark = MotorcycleDto.Mark,
                YearManufacture = MotorcycleDto.YearManufacture,
                Type = MotorcycleDto.Type,
                ImageUrl = MotorcycleDto.ImageUrl,
                Engine = MotorcycleDto.Engine,
                Power = MotorcycleDto.Power,
                MaximumSpeed = MotorcycleDto.MaximumSpeed,
                FuelType = MotorcycleDto.FuelType,
                Transmission = MotorcycleDto.Transmission,
                EngineDisplacement = MotorcycleDto.EngineDisplacement,
                TypeHandlebar = MotorcycleDto.TypeHandlebar,
                BrakeType = MotorcycleDto.BrakeType,

            };

            _appDbContext.Motorcycles.Add(Motorcycle);
            await _appDbContext.SaveChangesAsync();

            return StatusCode(201, Motorcycle);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MotorcycleReadDto>>> GetAllexistings()
        {
            var motorcycles = await _appDbContext.Motorcycles.ToListAsync();
            var MotorcycleDto = motorcycles.Select(c => new MotorcycleReadDto
            {
                Id = c.Id,
                Name = c.Name,
                Mark = c.Mark,
                YearManufacture = c.YearManufacture,
                Type = c.Type,
                ImageUrl = c.ImageUrl,
                EngineDisplacement = c.EngineDisplacement,
                TypeHandlebar = c.TypeHandlebar,
                BrakeType = c.BrakeType,
                

            }).ToList();

            return Ok(MotorcycleDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MotorcycleReadDto>> GetexistingById(int id)
        {
            var Motorcycle = await _appDbContext.Motorcycles.FindAsync(id);

            if (Motorcycle == null)
            {
                return NotFound();
            }
            var MotorcycleDto = new MotorcycleReadDto
            {
                Id = Motorcycle.Id,
                Name = Motorcycle.Name,
                Mark = Motorcycle.Mark,
                YearManufacture = Motorcycle.YearManufacture,
                Type = Motorcycle.Type,
                ImageUrl = Motorcycle.ImageUrl,
                EngineDisplacement = Motorcycle.EngineDisplacement,
                TypeHandlebar = Motorcycle.TypeHandlebar,
                BrakeType = Motorcycle.BrakeType,

            };

            return Ok(MotorcycleDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Updateexisting(int id, [FromBody] MotorcycleCreateDto updatedMotorcycle)
        {
            var existingMotorcycles = await _appDbContext.Motorcycles.FindAsync(id);

            if (existingMotorcycles == null)
            {
                return NotFound("Motorcycle not found");
            }

            _appDbContext.Entry(existingMotorcycles).CurrentValues.SetValues(updatedMotorcycle);

            await _appDbContext.SaveChangesAsync();

            return StatusCode(201, existingMotorcycles);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMotorcycle(int id)
        {
            var Motorcycle = await _appDbContext.Motorcycles.FindAsync(id);

            if (Motorcycle == null)
            {
                return NotFound("existing not found");
            }

            _appDbContext.Motorcycles.Remove(Motorcycle);

            await _appDbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}