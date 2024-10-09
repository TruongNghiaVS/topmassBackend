﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using topmass.Controllers;
using Topmass.core.Business;

namespace topmass.Model
{
    [ApiController]
    [Authorize]
    public class EducationController : BaseController
    {

        private readonly ILogger<EducationController> _logger;

        private readonly IProfileBusiness _profileBusiness;

        public EducationController(ILogger<EducationController> logger,

            IProfileBusiness profileBusiness
            ) : base(logger)
        {
            _logger = logger;

            _profileBusiness = profileBusiness;
        }
        [HttpPost]
        public async Task<ActionResult> AddEducation(InputEducationUserRequestAdd requestAdd)
        {
            var resultUser = await GetCurrentUser();
            var baseReult = new BaseResult();

            if (string.IsNullOrEmpty(requestAdd.SchoolName))
            {
                baseReult.AddError(nameof(requestAdd.SchoolName), "Thiếu thông tin trường");
            }

            if (!baseReult.Success)
            {
                return StatusCode(baseReult.StatusCode, baseReult);
            }

            var request = new EducationUserInfoRequest()
            {
                FromMonth = requestAdd.FromMonth,
                FromYear = requestAdd.FromYear,
                Introduction = requestAdd.Introduction,
                LinkFile = requestAdd.LinkFile,
                SchoolName = requestAdd.SchoolName,
                IsEnd = requestAdd.IsEnd,
                Major = requestAdd.Major,
                Position = requestAdd.Position,
                ToMonth = requestAdd.ToMonth,
                ToYear = requestAdd.ToYear,
                UserId = int.Parse(resultUser.Id)
            };
            var data = await _profileBusiness.AddEducation(request);
            baseReult.Data = data;
            return StatusCode(baseReult.StatusCode, baseReult);

        }


        [HttpPost]
        public async Task<ActionResult> SaveEducations(List<InputEducationUserRequestAdd> requestAdd)
        {
            var resultUser = await GetCurrentUser();
            var baseReult = new BaseResult();


            foreach (var item in requestAdd)
            {
                if (string.IsNullOrEmpty(item.SchoolName))
                {
                    baseReult.AddError(nameof(item.SchoolName), "Thiếu thông tin trường");
                }
            }

            if (!baseReult.Success)
            {
                return StatusCode(baseReult.StatusCode, baseReult);
            }

            var request = new EducationUserInfoRequest()
            {

                UserId = int.Parse(resultUser.Id)
            };
            foreach (var item in requestAdd)
            {
                if (item.Id < 1)
                {

                    var requestInsert = new EducationUserInfoUpdateRequest()
                    {
                        FromMonth = item.FromMonth,
                        FromYear = item.FromYear,
                        Introduction = item.Introduction,
                        LinkFile = item.LinkFile,
                        SchoolName = item.SchoolName,
                        IsEnd = item.IsEnd,
                        Major = item.Major,
                        Position = item.Position,
                        ToMonth = item.ToMonth,
                        ToYear = item.ToYear,
                        Rank = item.Rank,

                        UserId = int.Parse(resultUser.Id)
                    };
                    await _profileBusiness.AddEducation(requestInsert);

                }
                else
                {
                    var requestUpdate = new EducationUserInfoUpdateRequest()
                    {
                        FromMonth = item.FromMonth,
                        FromYear = item.FromYear,
                        Introduction = item.Introduction,
                        LinkFile = item.LinkFile,
                        SchoolName = item.SchoolName,
                        IsEnd = item.IsEnd,
                        Major = item.Major,
                        Position = item.Position,
                        ToMonth = item.ToMonth,
                        ToYear = item.ToYear,
                        Rank = item.Rank,
                        UserId = int.Parse(resultUser.Id),
                        Id = item.Id
                    };
                    _profileBusiness.UpdateEducation(requestUpdate);
                }
            }


            baseReult.Data = true;
            return StatusCode(baseReult.StatusCode, baseReult);

        }


        [HttpPost]
        public async Task<ActionResult> UpdateEducation(InputEducationUserInfoUpdateRequest requestAdd)
        {
            var resultUser = await GetCurrentUser();
            var baseReult = new BaseResult();

            if (string.IsNullOrEmpty(requestAdd.SchoolName))
            {
                baseReult.AddError(nameof(requestAdd.SchoolName), "Thiếu thông tin trường");
            }

            if (!baseReult.Success)
            {
                return StatusCode(baseReult.StatusCode, baseReult);
            }
            var request = new EducationUserInfoUpdateRequest()
            {
                FromMonth = requestAdd.FromMonth,
                FromYear = requestAdd.FromYear,
                Introduction = requestAdd.Introduction,
                LinkFile = requestAdd.LinkFile,
                SchoolName = requestAdd.SchoolName,
                IsEnd = requestAdd.IsEnd,
                Major = requestAdd.Major,
                Position = requestAdd.Position,
                ToMonth = requestAdd.ToMonth,
                ToYear = requestAdd.ToYear,
                UserId = int.Parse(resultUser.Id),
                Id = requestAdd.Id
            };
            var data = await _profileBusiness.UpdateEducation(request);
            baseReult.Data = data;
            return StatusCode(baseReult.StatusCode, baseReult);

        }

        [HttpPost]
        public async Task<ActionResult> DeleteEducation(InputProfileDelete requestAdd)
        {
            var resultUser = await GetCurrentUser();
            var baseReult = new BaseResult();
            if (requestAdd.Id < 1)
            {
                baseReult.AddError(nameof(requestAdd.Id), "Thiếu thông tin trường Id");
            }

            if (!baseReult.Success)
            {
                return StatusCode(baseReult.StatusCode, baseReult);
            }
            var data = await _profileBusiness.DeleteEducation(new EducationUserInfoDeleteRequest()
            {
                Id = requestAdd.Id
            });
            baseReult.Data = data;
            return StatusCode(baseReult.StatusCode, baseReult);

        }

        [HttpGet]
        public async Task<ActionResult> GetAllEducation()
        {
            var resultUser = await GetCurrentUser();
            var baseReult = new BaseResult();
            var data = await _profileBusiness.GetAllEducation(int.Parse(resultUser.Id));
            baseReult.Data = data;
            return StatusCode(baseReult.StatusCode, baseReult);

        }
    }
}
