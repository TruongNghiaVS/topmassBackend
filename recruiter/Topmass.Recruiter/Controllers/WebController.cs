using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Topmass.Recruiter.Bussiness;
using TopMass.Core.Result;
using TopMass.Web.Business;
namespace Topmass.Recruiter.Controllers
{
    [ApiController]

    public class WebController : BaseController
    {
        private readonly ILogger<WebController> _logger;
        private readonly IPageBusiness _pageBusiness;
        private readonly IRecruiterBusiness _recruiterBusiness;
        private readonly ICompanyBusiness _companyBusiness;
        public WebController(ILogger<WebController> logger,
            IRecruiterBusiness recruiterBusiness,

            ICompanyBusiness companyBusiness
          ) : base(logger)
        {
            _logger = logger;
            _recruiterBusiness = recruiterBusiness;
            _companyBusiness = companyBusiness;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> GetContentPage(string pageSlug)
        {
            var result = new BaseResult();
            if (string.IsNullOrEmpty(pageSlug))
            {
                result.AddError(nameof(pageSlug), "thiếu thông tin slug");
            }
            if (!result.Success)
            {
                return StatusCode(result.StatusCode, result);
            }
            var contentpage = await _pageBusiness.GetContentBySlug(pageSlug);
            if (contentpage == null)
            {
                result.AddError(nameof(pageSlug), "không có thông tin");

                return StatusCode(302, result);
            }
            result.Data = contentpage;
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> GetInfomationSEO(string pageSlug)
        {
            var result = new BaseResult();
            if (string.IsNullOrEmpty(pageSlug))
            {
                result.AddError(nameof(pageSlug), "thiếu thông tin slug");
            }
            if (!result.Success)
            {
                return StatusCode(result.StatusCode, result);
            }
            var contentpage = await _pageBusiness.GetContentBySlug(pageSlug);
            if (contentpage == null)
            {
                result.AddError(nameof(pageSlug), "không có thông tin");

                return StatusCode(302, result);
            }
            result.Data = contentpage;
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> GetAllPartner()
        {
            var datas = await _companyBusiness.GetAllPartner();

            return StatusCode(datas.StatusCode, datas.Data);
        }

    }

}
