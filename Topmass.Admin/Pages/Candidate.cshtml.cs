using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Topmass.Admin
{
    [Authorize]
    public class CandidateModel : BaseModel
    {
        private readonly ILogger<CandidateModel> _logger;
        public CandidateRequest RequestSearch { get; set; }
        public BaseList DataAll { get; set; }
        public int TotalRecord
        {

            get
            {
                return DataAll.Total;

            }
        }
        public CandidateModel(
            ILogger<CandidateModel> logger
            )
        {
            TitlePage = "Danh sách ứng cử viên";
            KeyPage = "candidate";
            _logger = logger;

            TableColumnText = new List<string>()
             {
                "STT",
                "Tên ứng cử viên",

                "Số điện thoại",

                "Người tạo",
                "Ngày tạo",
                "Cập nhật gần nhất",
                "Thao tác"
            };
        }

        public async Task<IActionResult> OnPostAddCandidateOrderMarketting(OrderCandidateMarkettingItemAdd request)
        {
            var listEror = new List<object>();

            if (request.JobId > 0)
            {

            }
            var checkDuplicate = await _empBusiness.CheckDuplicate(request.Email,
                request.PhoneNumber);
            if (checkDuplicate.Id > 0)
            {
                var itemError = new
                {
                    name = "txtPhone",
                    Content = "Thông tin số điện thoại hoặc email bị trùng thông tin"
                };
                listEror.Add(itemError);
            }
            if (listEror.Count > 0)
            {
                return new JsonResult(listEror)
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
            var result = await orderBussiness.AddCandidateOrderMarketting(request);
            var dataReponse = new
            {
                success = result
            };
            return new JsonResult(dataReponse)
            {
                StatusCode = StatusCodes.Status200OK
            };
        }

        public async Task<IActionResult> OnPostAdd(CandidateAdd request)
        {
            var listEror = new List<object>();

            if (string.IsNullOrEmpty(request.Name))
            {
                var itemError = new
                {
                    name = "txtName",
                    Content = "Thiếu thông tin tiêu đề"
                };
                listEror.Add(itemError);
            }
            if (request.Id < 1)
            {
                var checkDuplicate = await _empBusiness.CheckDuplicate(request.Email, request.Phone);
                if (checkDuplicate.Id > 0)
                {
                    var itemError = new
                    {
                        name = "txtPhone",
                        Content = "Thông tin số điện thoại hoặc email bị trùng thông tin"
                    };
                    listEror.Add(itemError);
                }
                if (listEror.Count > 0)
                {
                    return new JsonResult(listEror)
                    {
                        StatusCode = StatusCodes.Status400BadRequest
                    };
                }
            }
            GetInfoUser();
            request.CreatedBy = UserData.UserId;
            request.UpdatedBy = UserData.UserId;
            if (UserData.RoleCode != "4")
            {
                request.Source = 0;
            }

            var result = await _business.AddOrUpdate(request);
            var dataReponse = new
            {
                success = result
            };
            return new JsonResult(dataReponse)
            {
                StatusCode = StatusCodes.Status200OK

            };
        }

        public async Task<IActionResult> OnPostAddWidthOrder(CandidateOrderAdd request)
        {
            var listEror = new List<object>();
            if (string.IsNullOrEmpty(request.Name))
            {
                var itemError = new
                {
                    name = "txtName",
                    Content = "Thiếu thông tin tiêu đề"
                };
                listEror.Add(itemError);
            }

            if (string.IsNullOrEmpty(request.Phone))
            {
                var itemError = new
                {
                    name = "txtPhone",
                    Content = "Thiếu thông tin số điện thoại"
                };
                listEror.Add(itemError);
            }


            if (string.IsNullOrEmpty(request.CVLink) && string.IsNullOrEmpty(request.ShortDes))
            {
                var itemError = new
                {
                    name = "txtShortDes",
                    Content = "Thiếu thông tin file CV hoặc link CV liên quan"
                };
                listEror.Add(itemError);
            }
            GetInfoUser();
            var result = true;
            var dataReponse = new
            {
                success = result
            };
            await _business.AddCandidateWidthOrder(request);
            return new JsonResult(dataReponse)
            {
                StatusCode = StatusCodes.Status200OK

            };
        }

        public async Task<ActionResult> OnGet([FromQuery] CandidateRequest request)
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return Redirect("/Login");
            }
            GetInfoUser();

            return await GetAll(request);
        }

        public async Task<ActionResult> GetAll(CandidateRequest request2)
        {
            request2.UserId = UserData.UserId;
            request2.RoleCode = UserData.RoleCode;
            RequestSearch = request2;
            //DataAll = await _business.GetAll(request2);
            return Page();
        }

        public virtual async Task<PartialViewResult> OnGetFormEdit(int id)

        {
            GetInfoUser();
            var resultView = new Candidate()
            {
                Id = id,
                Name = "",
                Email = "",
                IsActive = 1,
                Status = 1,
                Deleted = false,
                Noted = ""
            };
            if (id > 0)
            {
                resultView = await _business.GetById(id);
            }

            var allJob = await _jobbussines.GetAll(new JobRequest()
            {
            });

            var allStatus = await imasterDataBussiness.GetAll(new CommonRequest()
            {
                Type = 4
            });
            var allOrder = await orderBussiness
            .GetALlHistory(new OrderRequest()
            {
                Phone = resultView.Phone,
                Email = resultView.Email
            });
            var resultObject = new
            {
                allJob,
                resultView,
                allStatus,
                allOrder

            };
            if (UserData.RoleCode == "4")
            {
                return Partial("EditOrUpdateCandidateMar", resultObject);
            }
            else if (UserData.RoleCode == "6" || UserData.RoleCode == "7")
            {
                return Partial("EditOrUpdateCandidateCTV", resultObject);
            }
            return Partial("EditOrUpdateCandidate", resultObject);
        }

        public async Task<IActionResult> OnPostDelete
      (int Id = -1)
        {

            var listEror = new List<object>();

            if (Id < 0)
            {
                var itemError = new
                {
                    name = "id",
                    Content = "Thiếu thông tin cần xoá"
                };
                listEror.Add(itemError);

            }
            if (listEror.Count > 0)
            {
                return new JsonResult(listEror)
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
            var result = true;
            result = await _business.Delete(Id);
            var dataReponse = new
            {
                success = result,

            };
            return new JsonResult(dataReponse)
            {
                StatusCode = StatusCodes.Status200OK

            };
        }




    }
}
