using Topmass.Bussiness.Company.Model;
using Topmass.Core.Model;

namespace Topmass.Bussiness.Company
{
    public interface ICompanyBusiness
    {
        public Task<GetAllCompanyReponse> GetAllCompany(GetAllCompanyRequest request);
        public Task<CompanyInfoModel> GetCompanyBySlug(string slug);
        public Task<dynamic> GetInfomationDetail(string slug, int userId = -1);
        public Task<dynamic> GetAllJobOfCompany(string slug, int userId = -1);

        public Task<dynamic> AddFollow(string slug, int userId);
    }
}
