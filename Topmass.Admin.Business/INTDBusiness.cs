using Topmass.Admin.Business.Model;
using TopMass.Core.Result;

namespace Topmass.Admin.Business
{
    public interface INTDBusiness : IBaseBusiness
    {
        public Task<SearchNTDReponse> GetAllNTD(SearchNTDRequest request);

        public Task<BaseResultAdd> AddNTD(NTDRequestAdd request);
    }
}
