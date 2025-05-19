
using Microsoft.AspNetCore.Mvc;
using AutoDexApi.DB;
using AutoDexApi.Models;
using AutoDexApi.Dtos;

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
                Doors = carDto.Doors,
                Traction = carDto.Traction,
                TypeSteering = carDto.TypeSteering
            };

            _appDbContext.Cars.Add(car);
            await _appDbContext.SaveChangesAsync();

            return StatusCode(201, car);
        }

    }

    
}