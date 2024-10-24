using Topmass.Campagn.Repository;
using Topmass.Core.Model.Admin;

namespace Topmass.Admin.Business
{
    public class LoginBusiness : BaseBusiness, IloginBusiness
    {
        public LoginBusiness(IAdminRepository _adminRepository) : base(_adminRepository)
        {

        }

        public async Task<Employer> Login(string userName, string password)
        {
            return await adminRepository.EmployeeRepository.Login(userName, password);

        }


    }
}
