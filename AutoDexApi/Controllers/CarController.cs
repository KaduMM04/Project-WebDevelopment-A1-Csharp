
using Microsoft.AspNetCore.Mvc;
using AutoDexApi.DB;
using AutoDexApi.Models;

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
        public async Task<IActionResult> AddCar(Car car)
        {
            if (car == null)
            {
                return BadRequest("invalid data");
            }

            _appDbContext.Cars.Add(car);
            await _appDbContext.SaveChangesAsync();

            return StatusCode(201, car);
        }

    }

    
}