using Microsoft.AspNetCore.Mvc;
using Topmass.Admin;
using Topmass.Admin.Business;
using Topmass.Admin.Pages.Model.search;

namespace crmHuman.Pages
{
    //[Authorize]

    public class NTDDetailModel : BaseModel
    {
        private readonly ILogger<NTDModel> _logger;

        public List<string> TableColumnTextAdmin { get; set; }
        public NTDRequest RequestSearch { get; set; }
        public BaseList DataAll { get; set; }

        public string TitlePage { get; set; }

        public string NameController { get; set; }
        public string KeyPage { get; set; }

        public List<string> TableColumnText { get; set; }
        private INTDBusiness business { get; set; }

        public int TotalRecord
        {

            get
            {
                return DataAll.Total;

            }
        }
        public NTDDetailModel(ILogger<NTDModel> logger,
            INTDBusiness _business

            )
        {
            _logger = logger;
            TitlePage = "Chi tiết NTD";
            KeyPage = "NTD";
            TableColumnText = new List<string>()
            {
                "STT","Mã","Tên người đại diện","Tên đăng nhập","Tên công ty", "MST", "Số điện thoại", "Trạng thái", "Cấp độ xác thực","Cập nhật gần nhất","Thao tác"
            };

            NameController = "NTDDetail";
            business = _business;
            DataAll = new BaseList();
        }
        public async Task<ActionResult> OnGet([FromQuery] NTDRequest request)
        {

            return await GetAll(request);
        }
        public async Task<ActionResult> GetAll(NTDRequest request2)
        {
            RequestSearch = request2;
            var dataAll = await business.GetAllNTD(new SearchNTDRequest()
            {

            });
            DataAll.Data = dataAll.Data;
            return Page();
        }

        public virtual async Task<PartialViewResult> OnGetFormEdit(int id)
        {
            var resultView = new
            {

            };
            return Partial("editOrUpdateEmployee", resultView);
        }


    }
}
