using Microsoft.Extensions.DependencyInjection;
using Topmass.Campagn.Repository;
using Topmass.Core.Repository;

namespace Topmass.Admin.Repository
{
    public static class DependencyRegister
    {
        public static void ConfigRepAdmin(this IServiceCollection services)
        {
            services.ConfigRep();
            services.AddSingleton<IAdminRepository, AdminRepository>();
            services.AddSingleton<IEmployeeeRepository, EmployerRepository>();

        }
    }
}
