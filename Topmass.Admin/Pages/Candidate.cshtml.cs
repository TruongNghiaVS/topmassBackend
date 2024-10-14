using Microsoft.AspNetCore.Authorization;

namespace Topmass.Admin
{
    [Authorize]
    public class CandidateModel : BaseModel
    {
        private readonly ILogger<CandidateModel> _logger;
    }
}
