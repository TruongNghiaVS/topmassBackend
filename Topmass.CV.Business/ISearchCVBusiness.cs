using Topmass.CV.Business.Model;

namespace Topmass.CV.Business
{
    public interface ISearchCVBusiness
    {
        public Task<bool> SaveResultSearch(CVRequestAdd request);
    }
}
