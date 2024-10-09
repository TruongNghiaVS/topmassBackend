using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Topmass.Admin.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ILogger<LoginModel> _logger;
        public LoginModel(ILogger<LoginModel> logger
            )
        {
            _logger = logger;
        }
        private async Task<IActionResult> Login(string userName, string pass)
        {
            return Redirect("/");
        }
        public async Task<string> GetPageName()
        {
            return "Trang đăng nhập";

        }
        public void OnGet()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {

                HttpContext.Response.Redirect("/");
            }
        }
        //public async Task<IActionResult> OnPostLogin(LoginRequest request)
        //{
        //    if (string.IsNullOrEmpty(request.UserName))
        //    {
        //        var listError = new
        //        {
        //            name = "UserName",
        //            Content = "Thiếu thông tin tên đăng nhập"
        //        };
        //        return StatusCode(StatusCodes.Status400BadRequest, listError);
        //    }

        //    var dataReponse = new
        //    {
        //        success = true,

        //    };
        //    return await Login(request.UserName, request.Password);


        //}
    }

}
