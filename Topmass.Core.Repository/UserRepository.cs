using Microsoft.Extensions.Configuration;
using Topmass.Core.Model;

namespace Topmass.Core.Repository
{
    public class UserRepository : RepositoryBase<UserModel>, IUserRepository
    {
        public UserRepository(IConfiguration configuration) : base(configuration)
        {
            tableName = "UserModel";
        }

    }
}
