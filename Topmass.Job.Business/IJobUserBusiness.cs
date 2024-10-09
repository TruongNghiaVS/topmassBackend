using Topmass.Job.Business.Model.webCan;

namespace Topmass.Job.Business
{
    public interface IJobUserBusiness
    {

        public Task<GetAllCVApplyReponse> GetAllCVApply(int userId);

        public Task<GetAllJpobSaveReponse> GetAllJobSave(int userId);

    }
}
