
using Microsoft.AspNetCore.Mvc;
using AutoDexApi.DB;

namespace AutoDexApi.Controllers
{
    [ApiController]
    [Route("Cars")]
    public class CarController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
    }
}