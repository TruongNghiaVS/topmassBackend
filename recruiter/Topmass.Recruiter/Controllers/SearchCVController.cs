using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Topmass.CV.Business;
using Topmass.CV.Business.Model;
using Topmass.Recruiter.Model;
using TopMass.Core.Result;

namespace Topmass.Recruiter.Controllers
{
    [ApiController]
    [Authorize]
    public class SearchCVController : BaseController
    {
        private readonly ILogger<SearchCVController> _logger;
        private readonly ICVBusiness _cVBusiness;
        private readonly ICVUtilities _cVUtilities;
        private readonly IProfileCVBusiness _profileCVBusiness;
        public SearchCVController(ILogger<SearchCVController> logger,

            ICVBusiness cVBusiness,
            ICVUtilities cVUtilities,
            IProfileCVBusiness profileCVBusiness
            ) : base(logger)
        {
            _logger = logger;
            _cVBusiness = cVBusiness;
            _cVUtilities = cVUtilities;
            _profileCVBusiness = profileCVBusiness;
        }

        [HttpGet]
        public async Task<ActionResult> Search([FromQuery] InputSearchCV request)
        {
            var resultUser = await GetCurrentUser();
            var reponse = new BaseResult();
            var searchRequest = new SearchCVRequestInfo()
            {
                CvKey = request.CvKey,
                DayOfBirth = request.DayOfBirth,
                EducationalLevelArray = request.EducationalLevelArray,
                Gender = request.Gender,
                KeyWord = request.KeyWord,
                Limit = request.Limit,
                LocationCode = request.LocationCode,
                Page = request.Page,
                SchoolSearch = request.SchoolSearch
            };
            var result = await _cVBusiness.SearchCV(searchRequest);
            reponse.Data = result;
            return StatusCode(reponse.StatusCode, reponse);
        }
        [HttpGet]
        public async Task<ActionResult> GetProfileGenerate(string? searchId)
        {
            var resultUser = await GetCurrentUser();
            var result = await _profileCVBusiness.GetFullProfileUser(searchId);
            return StatusCode(result.StatusCode, result);
        }
        [HttpGet]
        public async Task<ActionResult> GetDetailInfo(string searchId)
        {
            var resultUser = await GetCurrentUser();
            var reponse = new BaseResult();
            var result = await _profileCVBusiness.GetDetailInfo(searchId, resultUser.UserId);
            reponse.Data = result;
            return StatusCode(reponse.StatusCode, reponse);
        }

        [HttpPost]
        public async Task<ActionResult> SaveSearchCV(int searchId, int campaignId)
        {
            var resultUser = await GetCurrentUser();
            var reponse = new BaseResult();
            return StatusCode(reponse.StatusCode, reponse);
        }
        [HttpPost]
        public async Task<ActionResult> OpenCV(int searchId)
        {
            var resultUser = await GetCurrentUser();


            var reponse = new BaseResult();

            return StatusCode(reponse.StatusCode, reponse);
        }

    }
}
