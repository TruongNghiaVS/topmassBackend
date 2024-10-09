using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Topmass.Business.History;
using TopMass.Core.Result;

namespace Topmass.Recruiter.Controllers
{
    [ApiController]
    [Authorize]
    public class HistoryController : BaseController
    {
        private readonly ILogger<JobController> _logger;
        private readonly IHistoryBussiness _bussiness;
        public HistoryController(ILogger<JobController> logger,
            IHistoryBussiness historyBussiness
            ) : base(logger)
        {
            _logger = logger;
            _bussiness = historyBussiness;

        }

        [HttpGet]
        public async Task<ActionResult> GetHistoryLogin()
        {
            var resultUser = await GetCurrentUser();
            var reponse = new BaseResult();
            var result = await _bussiness.GetAccessLog(resultUser.UserId, 2, 1);
            reponse.Data = result;
            return StatusCode(reponse.StatusCode, reponse);
        }


        [HttpGet]
        public async Task<ActionResult> GetLogUpdateAccount()
        {
            var resultUser = await GetCurrentUser();
            var reponse = new BaseResult();
            var result = await _bussiness.GetAccessLog(resultUser.UserId, 2, 2);
            reponse.Data = result;
            return StatusCode(reponse.StatusCode, reponse);
        }
    }
}
