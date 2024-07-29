using Microsoft.Extensions.DependencyInjection;
using Topmass.Core.Repository;

namespace Topmass.core.Business
{
    public static class DependencyRegister
    {
        public static void ConfigBusiness(this IServiceCollection services)
        {
            // singleton
            services.ConfigRep();
            services.AddSingleton<IUserBuisiness, UserBusiness>();
        }
    }
}
