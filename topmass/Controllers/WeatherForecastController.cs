using Microsoft.AspNetCore.Mvc;
using Topmass.core.Business;

namespace topmass.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;

        private readonly IUserBuisiness _business;
        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IUserBuisiness userBuisiness)
        {
            _logger = logger;
            _business = userBuisiness;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<ActionResult> Get()
        {    //demo
            var userCurrent = await _business.GetById(1);
            userCurrent.UserName = "nghiait10";
            await _business.AddOrUPdate(userCurrent);
            return Ok(userCurrent);
        }
    }
}
