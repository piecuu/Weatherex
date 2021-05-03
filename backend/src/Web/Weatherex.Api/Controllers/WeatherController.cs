using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Weatherex.Application.Interfaces;

namespace Weatherex.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet("{city}")]
        public async Task<IActionResult> GetWeatherInTimeAsync(string city)
        {
            var result = await _weatherService.GetWeatherInLocationAsync(city);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
