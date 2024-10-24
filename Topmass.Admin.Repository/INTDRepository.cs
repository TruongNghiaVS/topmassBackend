namespace Topmass.Admin.Repository
{
    public interface INTDRepository
    {
        public Task<dynamic> GetAl(NTDRequest request);
    }
}
