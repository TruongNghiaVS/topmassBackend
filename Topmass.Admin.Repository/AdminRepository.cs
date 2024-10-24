using Microsoft.Extensions.Configuration;
using Topmass.Core.Repository;

namespace Topmass.Campagn.Repository
{
    public partial class AdminRepository : BaseDataAccess, IAdminRepository
    {
        public ICompanyInfoRepository CompanyInfoRepository { get; set; }
        public IEmployeeeRepository EmployeeRepository { get; set; }
        public AdminRepository(IConfiguration configuration,
            ICompanyInfoRepository _companyInfoRepository,
            IEmployeeeRepository employeeeRepository
            ) : base(configuration)
        {
            CompanyInfoRepository = _companyInfoRepository;
            EmployeeRepository = employeeeRepository;
        }

    }
}
