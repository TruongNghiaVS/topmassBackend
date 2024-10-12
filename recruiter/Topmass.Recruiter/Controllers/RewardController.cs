using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Topmass.CV.Business;
using Topmass.Recruiter.Bussiness;
using Topmass.Recruiter.Model;
using TopMass.Core.Result;

namespace Topmass.Recruiter.Controllers
{
    [ApiController]
    [Authorize]
    public class RewardController : BaseController
    {
        private readonly ILogger<SearchCVController> _logger;
        private readonly IRewardBusiness _rewardBusiness;

        private readonly ISearchCVBusiness _searchCVBusiness;
        public RewardController(ILogger<SearchCVController> logger,
            IRewardBusiness rewardBusiness,
            ISearchCVBusiness searchCVBusiness
            ) : base(logger)
        {
            _logger = logger;
            _rewardBusiness = rewardBusiness;
            _searchCVBusiness = searchCVBusiness;
        }

        [HttpPost]
        public async Task<ActionResult> OpenCV(OpenSearchCVRequest request)
        {
            var resultUser = await GetCurrentUser();
            var reponse = new BaseResult();
            await _rewardBusiness.ExchangePointToOpenCV(request.SearchId,
                2, resultUser.UserId);
            return StatusCode(reponse.StatusCode, reponse);
        }

        [HttpPost]
        public async Task<ActionResult> SaveCV(OpenSearchCVRequest request)
        {
            var resultUser = await GetCurrentUser();
            var reponse = new BaseResult();
            await _rewardBusiness.ExchangePointToOpenCV(request.SearchId,
                2, resultUser.UserId);
            return StatusCode(reponse.StatusCode, reponse);
        }

    }
}
