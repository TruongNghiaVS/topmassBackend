using Topmass.Core.Model;

namespace Topmass.core.Business
{
    public partial interface IUserBuisiness : IBaseBusiness<UserModel>
    {
        public Task<LoginResult> Login(string username, string password);
    }
}
