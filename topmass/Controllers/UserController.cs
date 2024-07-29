using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Topmass.core.Business;

namespace topmass.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class UserController : BaseController
    {

        private readonly ILogger<UserController> _logger;

        private readonly IUserBuisiness _business;
        public UserController(ILogger<UserController> logger,
            IUserBuisiness userBuisiness) : base(logger, userBuisiness)
        {
            _logger = logger;
            _business = userBuisiness;
        }

        [HttpPost]
        public async Task<ActionResult> GetUserCurrent()
        {
            var resultUser = await GetCurrentUser();
            return Ok(resultUser);
        }




    }
}
