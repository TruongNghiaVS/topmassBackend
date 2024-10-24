using Topmass.Admin.Business.Model;
using Topmass.Campagn.Repository;
using TopMass.Core.Result;

namespace Topmass.Admin.Business
{
    public class NTDBusiness : BaseBusiness, INTDBusiness
    {

        public NTDBusiness(IAdminRepository _adminRepository) : base(_adminRepository)
        {

        }

        public async Task<SearchNTDReponse> GetAllNTD(SearchNTDRequest request)
        {
            var reponse = new SearchNTDReponse();
            var data = await this.adminRepository.ExecuteSqlProcerduceToList<NTDItemDisplay>("sp_ntd_getall", request, System.Data.CommandType.StoredProcedure);
            reponse.Data = data;
            return reponse;
        }
        public async Task<BaseResultAdd> AddNTD(NTDRequestAdd request)
        {
            var reponse = new BaseResultAdd();





            return reponse;

        }
    }
}
