using Topmass.CV.Business.Model;
using Topmass.CV.Repository;

namespace Topmass.CV.Business
{
    public class SearchCVBusiness : ISearchCVBusiness
    {
        private readonly ICVRepository _cVRepository;
        public SearchCVBusiness(ICVRepository cVRepository
            )
        {
            _cVRepository = cVRepository;
        }
        public async Task<bool> SaveResultSearch(CVRequestAdd request)
        {
            return true;
        }

    }
}
