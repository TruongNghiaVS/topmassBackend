using Topmass.Core.Model;

namespace Topmass.Core.Repository
{
    public interface IBaseRepository<T> where T : BaseModel, new()
    {

        Task<IEnumerable<T>> GetAllBase();
        public Task<bool> AddOrUPdate(T itemModel);
        public Task<bool> Delete(T itemModel);
        public Task<bool> Delete(int id);
        public Task<T> GetById(int id);


    }
}
