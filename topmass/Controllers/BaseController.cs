using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using topmass.Model;
using Topmass.core.Business;

namespace topmass.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController : ControllerBase
    {

        private readonly ILogger<BaseController> _logger;
        private readonly IUserBuisiness _business;
        public BaseController(ILogger<BaseController> logger,
            IUserBuisiness userBuisiness)
        {
            _logger = logger;

            _business = userBuisiness;
        }

        protected async Task<AuthenInfo> GetCurrentUser()
        {
            var identity = User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;
                var idUser = identity.Claims.FirstOrDefault(o => o.Type == "userId")?.Value;
                var userName = userClaims.FirstOrDefault(o => o.Type == "userName")?.Value;
                var roleId = userClaims.FirstOrDefault(o => o.Type == "RoleUser")?.Value;
                var fullName = userClaims.FirstOrDefault(o => o.Type == "Name")?.Value;
                var lineCode = userClaims.FirstOrDefault(o => o.Type == "lineCode")?.Value;
                var vendorCode = userClaims.FirstOrDefault(o => o.Type == "vendorCode")?.Value;
                return new AuthenInfo
                {
                    UserName = userName,
                    Id = idUser
                };
            }
            return new AuthenInfo()
            {
                Id = "-1"
            };
        }
    }
}
