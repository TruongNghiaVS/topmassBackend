using Microsoft.AspNetCore.Mvc;
using Topmass.Admin.Pages.Model;

namespace Topmass.Admin.Pages
{
    public class IndexModel : BaseModel
    {
        private readonly ILogger<IndexModel> _logger;
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public UserDataView UserData
        {
            get; set;
        }
        public async Task<ActionResult> OnGet()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return Redirect("/Login");
            }
            return Page();
        }
    }
}
