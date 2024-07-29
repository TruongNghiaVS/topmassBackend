using Microsoft.AspNetCore.Mvc;
using Topmass.core.Business;

namespace topmass.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenController : ControllerBase
    {

        private readonly ILogger<BaseController> _logger;

        private readonly IUserBuisiness _business;
        public AuthenController(ILogger<BaseController> logger,
            IUserBuisiness userBuisiness)
        {
            _logger = logger;
            _business = userBuisiness;
        }

        [HttpGet(Name = "authen")]
        public async Task<ActionResult> User(string userName, string password)
        {
            var resultUser = await _business.Login(userName, password);
            return Ok(resultUser);

        }




    }
}
