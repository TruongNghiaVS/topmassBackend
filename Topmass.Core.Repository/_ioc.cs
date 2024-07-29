using Microsoft.Extensions.DependencyInjection;

namespace Topmass.Core.Repository
{
    public static class DependencyRegister
    {

        public static void ConfigRep(this IServiceCollection services)
        {

            services.AddSingleton<IUserRepository, UserRepository>();



        }
    }
}
