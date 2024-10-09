using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using topmass.Controllers;
using Topmass.Job.Business;
using Topmass.Job.Business.Model;
using TopMass.Core.Result;

namespace topmass.Model
{
    [ApiController]

    public class JobWebController : BaseController
    {

        private readonly ILogger<JobWebController> _logger;

        private readonly IJobBusiness _jobBusiness;
        public JobWebController(ILogger<JobWebController> logger,
            IJobBusiness jobBusiness
            ) : base(logger)
        {
            _logger = logger;


            _jobBusiness = jobBusiness;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> GetDetailInfo([FromQuery] InputJobInfoRequest request)
        {
            var reponse = new BaseResult();
            if (string.IsNullOrEmpty(request.JobId))
            {
                reponse.AddError(nameof(request.JobId), "Missing jobId");
                return StatusCode(reponse.StatusCode, reponse);
            }
            var rquest = new CandidateJobInfoRequest()
            {
                Slug = request.JobId
            };
            if (User.Identity.IsAuthenticated)
            {
                var resultUser = await GetCurrentUser();
                rquest.UserId = int.Parse(resultUser.Id);
            }
            var result = await _jobBusiness.GetInfoJOb(rquest);
            reponse.Data = result;
            return StatusCode(reponse.StatusCode, reponse);

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> GetRelationJob([FromQuery] InputJobInfo request)
        {
            var reponse = new BaseResult();
            if (string.IsNullOrEmpty(request.JobId))
            {
                reponse.AddError(nameof(request.JobId), "Missing jobId");
                return StatusCode(reponse.StatusCode, reponse);
            }
            var rquest = new JobRelattionRequest()
            {
                Slug = request.JobId
            };
            if (User.Identity.IsAuthenticated)
            {
                var resultUser = await GetCurrentUser();
                rquest.UserId = int.Parse(resultUser.Id);
            }
            var result = await _jobBusiness.GetRelationJob(rquest);
            reponse.Data = result;
            return StatusCode(reponse.StatusCode, reponse);

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> GetRecommended([FromQuery] InputJobInfo request)
        {
            var reponse = new BaseResult();

            if (string.IsNullOrEmpty(request.JobId))
            {
                reponse.AddError(nameof(request.JobId), "Missing jobId");
                return StatusCode(reponse.StatusCode, reponse);
            }
            var rquest = new JobRelattionRequest()
            {
                Slug = request.JobId
            };

            if (User.Identity.IsAuthenticated)
            {
                var resultUser = await GetCurrentUser();
                rquest.UserId = int.Parse(resultUser.Id);

            }
            var result = await _jobBusiness.GetRelationJob(rquest);
            reponse.Data = result;
            return StatusCode(reponse.StatusCode, reponse);
        }



    }
}
