using Microsoft.Extensions.DependencyInjection;
using Topmass.Admin.Repository;


namespace Topmass.Admin.Business
{
    public static class DependencyRegister
    {
        public static void ConfigAdminBusiness(this IServiceCollection services)
        {
            services.ConfigRepAdmin();
            services.AddSingleton<IloginBusiness, LoginBusiness>();
            services.AddSingleton<INTDBusiness, NTDBusiness>();
        }
    }
}
