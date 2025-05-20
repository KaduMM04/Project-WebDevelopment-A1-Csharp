
using Microsoft.AspNetCore.Mvc;
using AutoDexApi.DB;
using AutoDexApi.Models;
using AutoDexApi.Dtos;
using Microsoft.EntityFrameworkCore;

namespace AutoDexApi.Controllers
{
    [ApiController]
    [Route("Cars")]
    public class CarController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public CarController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddCar(CarCreateDto carDto)
        {
            if (carDto == null)
            {
                return BadRequest("invalid data");
            }

            var car = new Car()
            {
                Name = carDto.Name,
                Mark = carDto.Mark,
                YearManufacture = carDto.YearManufacture,
                Type = carDto.Type,
                ImageUrl = carDto.ImageUrl,
                Engine = carDto.Engine,
                Power = carDto.Power,
                MaximumSpeed = carDto.MaximumSpeed,
                FuelType = carDto.FuelType,
                Transmission = carDto.Transmission,
                Doors = carDto.Doors,
                Traction = carDto.Traction,
               
            };

            _appDbContext.Cars.Add(car);
            await _appDbContext.SaveChangesAsync();

            return StatusCode(201, car);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetAllCars()
        {
            var cars = await _appDbContext.Cars.ToListAsync();

            return Ok(cars);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCarById(int id)
        {
            var car = await _appDbContext.Cars.FindAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar(int id, [FromBody] CarCreateDto updatedCar)
        {
            var existingCar = await _appDbContext.Cars.FindAsync(id);

            if (existingCar == null)
            {
                return NotFound("Car not found");
            }

            _appDbContext.Entry(existingCar).CurrentValues.SetValues(updatedCar);

            await _appDbContext.SaveChangesAsync();

            return StatusCode(201, existingCar);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var car = await _appDbContext.Cars.FindAsync(id);

            if (car == null)
            {
                return NotFound("Car not found");
            }

            _appDbContext.Cars.Remove(car);

            await _appDbContext.SaveChangesAsync();

            return NoContent(); 
        }


    }

    
}