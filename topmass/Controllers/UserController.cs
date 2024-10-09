using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using topmass.Controllers;
using Topmass.core.Business;
using Topmass.CV.Business;
using Topmass.Job.Business;

namespace topmass.Model
{
    [ApiController]
    [Authorize]
    public class UserController : BaseController
    {

        private readonly ILogger<UserController> _logger;
        private readonly IJobUtilitiesBusiness _jobBusiness;
        private readonly IJobUserBusiness jobUserBusiness;
        private readonly IProfileBusiness _profileBusiness;




        public UserController(ILogger<UserController> logger,

            ICVBusiness cVBusiness,
            IJobUtilitiesBusiness jobBusiness,
            IJobUserBusiness _jobUserBusiness,
            IProfileBusiness profileBusiness
            ) : base(logger)
        {
            _logger = logger;

            _jobBusiness = jobBusiness;
            jobUserBusiness = _jobUserBusiness;
            _profileBusiness = profileBusiness;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllJobSave()
        {
            var resultUser = await GetCurrentUser();
            var baseReult = new BaseResult();

            var result = await jobUserBusiness.GetAllJobSave(resultUser.UserId);

            baseReult.Data = result.Data;
            return StatusCode(baseReult.StatusCode, baseReult);

        }

        [HttpGet]
        public async Task<ActionResult> GetAllCVApply()
        {
            var resultUser = await GetCurrentUser();
            var baseReult = new BaseResult();
            var data = await jobUserBusiness.GetAllCVApply(resultUser.UserId);
            baseReult.Data = data;
            return StatusCode(baseReult.StatusCode, baseReult);

        }

        [HttpPost]
        public async Task<ActionResult> SaveSkills(List<InputOtherProfileUserSaveSkill> requestAdd)
        {
            var resultUser = await GetCurrentUser();
            var baseReult = new BaseResult();
            foreach (var item in requestAdd)
            {
                if (string.IsNullOrEmpty(item.FullName))
                {
                    baseReult.AddError(nameof(item.FullName), "Thiếu thông tin trường");
                }
            }
            if (!baseReult.Success)
            {
                return StatusCode(baseReult.StatusCode, baseReult);
            }
            var listAdd = new List<AddOtherProfileRequest>();
            foreach (var item in requestAdd)
            {
                listAdd.Add(new AddOtherProfileRequest()
                {
                    Description = "",
                    FullName = item.FullName,
                    Level = item.Level,
                    TypeData = 1,
                    UserId = int.Parse(resultUser.Id),
                    Id = item.Id
                });
            }
            var data = await _profileBusiness.AddOtherProfileUser(listAdd);
            baseReult.Data = data;
            return StatusCode(baseReult.StatusCode, baseReult);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllSkills()
        {
            var resultUser = await GetCurrentUser();
            var baseReult = new BaseResult();
            var data = await _profileBusiness.GetAllOtherProfileUser(1, int.Parse(resultUser.Id));
            baseReult.Data = data;
            return StatusCode(baseReult.StatusCode, baseReult);
        }

        [HttpPost]
        public async Task<ActionResult> SaveSoftSkills(List<InputOtherProfileUserRequestAdd> requestAdd)
        {
            var resultUser = await GetCurrentUser();
            var baseReult = new BaseResult();
            foreach (var item in requestAdd)
            {
                if (string.IsNullOrEmpty(item.FullName))
                {
                    baseReult.AddError(nameof(item.FullName), "Thiếu thông tin trường");
                }
            }
            if (!baseReult.Success)
            {
                return StatusCode(baseReult.StatusCode, baseReult);
            }
            var listAdd = new List<AddOtherProfileRequest>();
            foreach (var item in requestAdd)
            {
                listAdd.Add(new AddOtherProfileRequest()
                {
                    Description = item.Description,
                    FullName = item.FullName,
                    Level = item.Level,
                    TypeData = 2,
                    UserId = int.Parse(resultUser.Id),
                    Id = item.Id
                });
            }
            var data = await _profileBusiness.AddOtherProfileUser(listAdd);
            baseReult.Data = data;
            return StatusCode(baseReult.StatusCode, baseReult);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllSoftSkills()
        {
            var resultUser = await GetCurrentUser();
            var baseReult = new BaseResult();
            var data = await _profileBusiness.GetAllOtherProfileUser(2, int.Parse(resultUser.Id));
            baseReult.Data = data;
            return StatusCode(baseReult.StatusCode, baseReult);

        }

        [HttpPost]
        public async Task<ActionResult> SaveTools(List<InputOtherProfileUserRequestAdd> requestAdd)
        {
            var resultUser = await GetCurrentUser();
            var baseReult = new BaseResult();

            foreach (var item in requestAdd)
            {
                if (string.IsNullOrEmpty(item.FullName))
                {
                    baseReult.AddError(nameof(item.FullName), "Thiếu thông tin trường");
                }
            }

            if (!baseReult.Success)
            {
                return StatusCode(baseReult.StatusCode, baseReult);
            }
            var listAdd = new List<AddOtherProfileRequest>();

            foreach (var item in requestAdd)
            {

                listAdd.Add(new AddOtherProfileRequest()
                {
                    Description = item.Description,
                    FullName = item.FullName,
                    Level = item.Level,
                    TypeData = 3,
                    UserId = int.Parse(resultUser.Id),
                    Id = item.Id
                });

            }
            var data = await _profileBusiness.AddOtherProfileUser(listAdd);
            baseReult.Data = data;
            return StatusCode(baseReult.StatusCode, baseReult);

        }


        [HttpGet]
        public async Task<ActionResult> GetAllTools()
        {
            var resultUser = await GetCurrentUser();
            var baseReult = new BaseResult();
            var data = await _profileBusiness.GetAllOtherProfileUser(3, int.Parse(resultUser.Id));
            baseReult.Data = data;
            return StatusCode(baseReult.StatusCode, baseReult);

        }




        [HttpPost]
        public async Task<ActionResult> SaveProfileCv(InputProfileUserRequestAdd requestAdd)
        {
            var resultUser = await GetCurrentUser();
            var baseReult = new BaseResult();
            if (!baseReult.Success)
            {
                return StatusCode(baseReult.StatusCode, baseReult);
            }
            var requestInsert = new ProfileUserRequestAdd()
            {
                Email = requestAdd.Email,
                UserId = resultUser.UserId,
                AvatarLink = requestAdd.AvatarLink,
                AddressInfo = requestAdd.AddressInfo,
                FullName = requestAdd.FullName,
                Gender = requestAdd.Gender,
                Introduction = requestAdd.Introduction,
                PhoneNumber = requestAdd.PhoneNumber,
                Position = requestAdd.Position,
                Level = requestAdd.level
            };
            var data = await _profileBusiness.AddOrUpdateProfileCV(requestInsert);
            baseReult.Data = data;
            return StatusCode(baseReult.StatusCode, baseReult);

        }

        [HttpGet]
        public async Task<ActionResult> GetProfileUserCV()
        {
            var resultUser = await GetCurrentUser();

            int userId = resultUser.UserId;
            var baseReult = new BaseResult();
            var dataInfo = await _profileBusiness.GetProfileUserCV(userId);
            baseReult.Data = dataInfo;
            return StatusCode(baseReult.StatusCode, baseReult);

        }


        [HttpGet]
        public async Task<ActionResult> GetFullProfileUser()
        {
            var resultUser = await GetCurrentUser();

            int userId = resultUser.UserId;
            var baseReult = new BaseResult();
            var educations = await _profileBusiness.GetAllEducation(userId);
            var experiences = await _profileBusiness.GetAllExperience(userId);
            var allProjects = await _profileBusiness.GetAllProjectUser(userId);
            var allSkill = await _profileBusiness.GetAllOtherProfileUser(1, userId);
            var allsoftSkill = await _profileBusiness.GetAllOtherProfileUser(2, userId);
            var allTools = await _profileBusiness.GetAllOtherProfileUser(3, userId);
            var allReward = await _profileBusiness.GetAllCertifyUser(userId, 2);
            var allCertify = await _profileBusiness.GetAllCertifyUser(userId, 1);
            var profileCv = await _profileBusiness.GetProfileUserCV(userId);
            var dataInfo = new
            {
                educations = educations.Data,
                experiences = experiences.Data,
                allProjects = allProjects.Data,
                allSkill = allSkill.Data,
                allsoftSkill = allsoftSkill.Data,
                allTools = allTools.Data,
                allReward = allReward.Data,
                allCertify = allCertify.Data,
                profileCv
            };

            baseReult.Data = dataInfo;
            return StatusCode(baseReult.StatusCode, baseReult);

        }

    }
}
