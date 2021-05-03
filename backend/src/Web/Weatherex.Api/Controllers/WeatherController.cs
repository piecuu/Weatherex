using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weatherex.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WeatherController : ControllerBase
    {
        public WeatherController()
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetWeatherInTimeAsync(string city)
        {

        }
    }
}
