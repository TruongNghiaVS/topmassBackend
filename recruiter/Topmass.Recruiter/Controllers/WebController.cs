using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using TopMass.Core.Result;
using TopMass.Web.Business;
namespace Topmass.Recruiter.Controllers
{
    [ApiController]

    public class WebController : BaseController
    {

        private readonly ILogger<WebController> _logger;
        private readonly IPageBusiness _pageBusiness;
        public WebController(ILogger<WebController> logger,
          IPageBusiness pageBusiness) : base(logger)
        {
            _logger = logger;
            _pageBusiness = pageBusiness;
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

    }
}
