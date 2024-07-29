using Topmass.core.Business.Model;

namespace Topmass.core.Business
{
    public interface IAuthen

    {
        Task<AuthenInfo> GetAuthenInfo();

    }
}
