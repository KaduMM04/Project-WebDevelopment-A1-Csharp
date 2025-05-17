
using Microsoft.AspNetCore.Mvc;
using AutoDexApi.DB;

namespace AutoDexApi.Controllers
{
    [ApiController]
    [Route("Motorcycles")]
    public class MotorcyclesController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
    }
}