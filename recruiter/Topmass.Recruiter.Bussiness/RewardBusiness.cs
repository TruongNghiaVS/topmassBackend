using Topmass.Core.Model;
using Topmass.Core.Model.Reward;
using Topmass.Recruiter.Bussiness.Model;
using Topmass.Recruiter.Repository;
using Topmass.Utility;
using TopMass.Core.Result;

namespace Topmass.Recruiter.Bussiness
{
    public partial class RewardBusiness : IRewardBusiness
    {
        private readonly IRecruiterRepository _repository;
        private readonly IRecruiterInfoRepository _infoRepository;
        private readonly IRewardTransactionRepository _rewardTransactionRepository;
        public RewardBusiness(IRecruiterRepository userRepository,
             IRecruiterInfoRepository infoRepository,
             IRewardTransactionRepository rewardTransactionRepository

            )
        {
            _repository = userRepository;
            _infoRepository = infoRepository;
            _rewardTransactionRepository = rewardTransactionRepository;

        }

        private string GetFullLink(string shortLink)
        {
            if (string.IsNullOrEmpty(shortLink) || string.IsNullOrWhiteSpace(shortLink))
            {
                return string.Empty;
            }
            return "http://42.115.94.180:8584/static/" + shortLink;

        }
        private string GetValueString(string valueString)
        {
            if (string.IsNullOrEmpty(valueString) || string.IsNullOrWhiteSpace(valueString))
            {
                return string.Empty;
            }
            return valueString;

        }

        public async Task<BaseResult> ExchangePointToOpenCV(int searchId, int point, int userId)
        {
            var reponse = new BaseResult();
            var result = new RecruiterInfoResult();
            var recruiterItem = await _repository.GetById(userId);
            if (recruiterItem == null)
            {
                return reponse;
            }
            if (recruiterItem.NumberLightning < 1)
            {
                reponse.AddError("reward", "Không đủ tia sét để mở CV, vui lòng thu thập tia sét thử sa");
            }
            if (recruiterItem.NumberLightning <= point)
            {
                reponse.AddError("reward", "Không đủ tia sét để mở CV, vui lòng thu thập thêm tia sét để mở");
            }
            recruiterItem.NumberLightning += -point;
            await _repository.AddOrUPdate(recruiterItem);

            var historyItem = new RewardTransaction()
            {
                BusinessDate = DateTime.Now,
                Content = "Dùng " + point + " tia sét để mở CV",
                CreateAt = DateTime.Now,
                Rel = userId,
                Point = point,
                CreatedBy = userId,
                Status = 0,
                Deleted = false,
                UpdateAt = DateTime.Now,
                UpdatedBy = userId
            };
            return reponse;
        }
        private string getStatusBusiness(int inputStatus)
        {
            if (inputStatus == 0)
            {
                return "Chưa ghi nhận thông tin";
            }
            if (inputStatus == 1)
            {
                return "Chờ duyệt";
            }

            if (inputStatus == 2)
            {
                return "Từ chối";
            }
            if (inputStatus == 3)
            {
                return "Đã duyệt";
            }
            return "Chưa nhận thông tin";
        }
        public async Task<BaseResult> UpdateInfoRecruiter(RecruiterInfoUpdate request)
        {
            var reponse = new BaseResult();


            var itemInfo = await _repository.GetById(request.RecuruiterId);


            if (itemInfo == null)
            {
                return reponse;
            }

            if (!string.IsNullOrEmpty(request.Phone))
            {
                itemInfo.Phone = request.Phone;
            }
            if (!string.IsNullOrEmpty(request.Taxcode))
            {
                itemInfo.TaxCode = request.Taxcode;
            }
            if (!string.IsNullOrEmpty(request.Name))
            {
                itemInfo.Name = request.Name;
            }
            itemInfo.UpdatedBy = request.HandleBy;
            itemInfo.UpdateAt = DateTime.Now;
            await _repository.AddOrUPdate(itemInfo);

            var recuruiterInfo = await _infoRepository.GetByUserName(itemInfo.Email);

            if (recuruiterInfo != null)
            {
                if (!string.IsNullOrEmpty(request.AvatarLink))
                {
                    recuruiterInfo.AvatarLink = request.AvatarLink;
                }

                if (request.Gender.HasValue)
                {
                    recuruiterInfo.Gender = request.Gender;
                }
                recuruiterInfo.UpdatedBy = request.HandleBy;
                recuruiterInfo.UpdateAt = DateTime.Now;
                await _infoRepository.AddOrUPdate(recuruiterInfo);

            }
            return reponse;
        }

        public async Task<BaseResult> UpdateCompanyInfo(CompanyInfoRequestUpdate request)
        {
            var reponse = new BaseResult();
            var itemInfo = await _companyInfoRepository.GetByUserName(request.Email);
            if (itemInfo == null)
            {
                itemInfo = new CompanyInfoModel();
                itemInfo.RelId = request.HandleBy;
                itemInfo.Email = request.Email;
            }

            itemInfo.Website = request.Website;
            itemInfo.Capacity = request.Capacity;
            itemInfo.LogoLink = request.LogoLink;
            itemInfo.TaxCode = request.TaxCode;
            itemInfo.CoverLink = request.CoverLink;
            itemInfo.FullName = request.FullName;
            itemInfo.AddressInfo = request.AddressInfo;
            itemInfo.shortDes = request.ShortDes;
            itemInfo.UpdatedBy = request.HandleBy;
            itemInfo.EmailCompany = request.EmailCompany;
            itemInfo.Phone = request.Phone;
            itemInfo.MapInfo = request.MapInfo;
            itemInfo.UpdateAt = DateTime.Now;
            itemInfo.Field = request.Field;
            itemInfo.Slug = Utilities.SlugifySlug(request.FullName);
            await _companyInfoRepository.AddOrUPdate(itemInfo);
            return reponse;
        }

        public async Task<BaseResult> UpdateBusinessLicense(BusinessLicenseRequestUpdate request)
        {
            var reponse = new BaseResult();
            var itemInfo = await _businessLicenseRepository.GetByUserName(request.Email);
            if (itemInfo == null || itemInfo.Id < 1)
            {
                itemInfo = new BusinessLicenseModel();
                itemInfo.Email = request.Email;
                itemInfo.Status = 0;
                itemInfo.CreateAt = DateTime.Now;
                itemInfo.CreatedBy = request.HandleBy;
                itemInfo.UpdateAt = DateTime.Now;
                itemInfo.UpdatedBy = request.HandleBy;
            }
            if (!string.IsNullOrEmpty(request.LinkFile))
            {
                if (itemInfo.LinkFile != request.LinkFile)
                {
                    itemInfo.LinkFile = request.LinkFile;
                    itemInfo.Status = 1;
                }

            }
            await _businessLicenseRepository.AddOrUPdate(itemInfo);

            return reponse;
        }

        public async Task<UserResgisterResult> RegisterUser(RecruiterRegisterRequest request)
        {
            var reponse = new UserResgisterResult();

            if (string.IsNullOrEmpty(request.Name) ||
            string.IsNullOrWhiteSpace(request.Name)
            )
            {
                reponse.AddError("Name", "Thiếu thông tin MST");
            }
            if (string.IsNullOrEmpty(request.Email) ||
                string.IsNullOrWhiteSpace(request.Email)
                )
            {
                reponse.AddError("Email", "Thiếu thông tin email");
            }
            if (string.IsNullOrEmpty(request.Password) ||
              string.IsNullOrWhiteSpace(request.Password)
              )
            {
                reponse.AddError("Password", "Thiếu thông tin mật khẩu");
            }

            if (string.IsNullOrEmpty(request.TaxCode) ||
                 string.IsNullOrWhiteSpace(request.TaxCode))
            {
                reponse.AddError("TaxCode", "Thiếu thông tin MST");
            }

            if (string.IsNullOrWhiteSpace(request.Phone)
            )
            {
                reponse.AddError("Phone", "Thiếu thông tin số điện thoại");

            }
            var itemInsert = new RecruiterRepAdd()
            {
                UserName = request.Email,
                Name = request.Name,
                TaxCode = request.TaxCode,
                Email = request.Email,
                Phone = request.Phone,
                CreatedBy = 1,
                Pass = request.Password
            };

            var itemDup = await _repository
            .FindOneByStatementSql<RecruiterModel>("select top 1 * from  Recruiter where email = @Email", new
            {
                itemInsert.Email
            });

            if (itemDup != null)
            {
                reponse.AddError(nameof(itemInsert.Email), "Trùng lặp thông tin Email ");

            }
            if (!reponse.Success)
            {
                return reponse;
            }
            await _repository.AddUser(itemInsert);
            var item = new ActiveCodeRecruiter();
            var randomCode = "" + new Random().Next(1000, 10000) + DateTime.Now.Ticks + "";
            item.Code = randomCode;
            item.Email = itemInsert.Email;
            item.Status = 1;
            item.CreateAt = DateTime.Now;
            await _activeCodeRecruiterRepository.AddOrUPdate(item);





            await _mailBussiness.RecruitmentSuccessRegister(item.Email);



            return reponse;

        }
        //public async Task<BaseResult> UpdateInfoRecruiter(RecruiterInfoUpdate request)
        //{
        //    var reponse = new UserResgisterResult();
        //    var candidateUpdate = await _repository.GetById(request.UserId.Value);

        //    if (candidateUpdate == null)
        //    {
        //        return reponse;
        //    }

        //    if (!string.IsNullOrEmpty(request.Name))
        //    {
        //        candidateUpdate.Name = request.Name;
        //    }

        //    if (!string.IsNullOrEmpty(request.Phone))
        //    {
        //        candidateUpdate.Phone = request.Phone;
        //    }


        //    if (!string.IsNullOrEmpty(request.Taxcode))
        //    {
        //        candidateUpdate.TaxCode = request.Taxcode;
        //    }



        //    candidateUpdate.UpdatedBy = request.HandleBy.Value;

        //    await _repository.AddOrUPdate(candidateUpdate);

        //    var candidateInfo = await _repository.FindOneByStatementSql<RecruiterInfoModel>("select top 1 * from RecruiterInfo where email = @email", new { email = candidateUpdate.Email });

        //    if (candidateInfo == null)
        //    {
        //        return reponse;
        //    }

        //    if (!string.IsNullOrEmpty(request.AvatarLink))
        //    {
        //        candidateInfo.AvatarLink = request.AvatarLink;
        //    }
        //    if (request.Gender.HasValue)
        //    {
        //        candidateInfo.Gender = request.Gender;
        //    }

        //    await _infoRepository.AddOrUPdate(candidateInfo);
        //    return reponse;
        //}


        public async Task<BaseResult> ChangePassword(string password, int userId)
        {
            var reponse = new BaseResult();
            var itemChange = await _repository.GetById(userId);
            if (itemChange == null)
            {
                return reponse;
            }
            itemChange.Password = password;
            itemChange.UpdateAt = DateTime.Now;
            await _repository.AddOrUPdate(itemChange);
            reponse.Message = "Cập nhật mật khẩu thành công";

            return reponse;
        }
    }
}
