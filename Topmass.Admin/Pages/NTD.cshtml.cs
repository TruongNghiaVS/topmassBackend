using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Topmass.Admin.Pages.Model.search;

namespace crmHuman.Pages
{
    //[Authorize]
    public class NTDModel : PageModel
    {
        private readonly ILogger<NTDModel> _logger;

        public List<string> TableColumnTextAdmin { get; set; }
        public NTDRequest RequestSearch { get; set; }
        public BaseList DataAll { get; set; }

        public string TitlePage { get; set; }

        public string NameController { get; set; }
        public string KeyPage { get; set; }

        public List<string> TableColumnText { get; set; }

        public int TotalRecord
        {

            get
            {
                return DataAll.Total;

            }
        }
        public NTDModel(ILogger<NTDModel> logger

            )
        {
            _logger = logger;
            TitlePage = "Danh sách nhà tuyển dụng";
            KeyPage = "Employee";
            TableColumnText = new List<string>()
            {
                "STT","Họ tên","Tài khoản","Vai trò","Line gọi","Nhóm", "Ngày Onboard","Cập nhật gần nhất","Thao tác"
            };

            NameController = "NTD";
        }



        public async Task<ActionResult> OnGet([FromQuery] NTDRequest request)
        {

            return await GetAll(request);
        }

        public async Task<ActionResult> GetAll(NTDRequest request2)
        {
            RequestSearch = request2;


            return Page();
        }

        public virtual async Task<PartialViewResult> OnGetFormEdit(int id)

        {
            //GetInfoUser();
            var resultView = new
            {

            };

            //if (id > 0)
            //{
            //    resultView = await _empBusiness.GetById(id);

            //}
            return Partial("editOrUpdateEmployee", resultView);
        }


        //  public async Task<IActionResult> OnPostDelete
        //(int Id = -1)
        //  {

        //      var listEror = new List<object>();

        //      if (Id < 0)
        //      {
        //          var itemError = new
        //          {
        //              name = "id",
        //              Content = "Thiếu thông tin cần xoá"
        //          };
        //          listEror.Add(itemError);

        //      }
        //      if (listEror.Count > 0)
        //      {
        //          return new JsonResult(listEror)
        //          {
        //              StatusCode = StatusCodes.Status400BadRequest
        //          };
        //      }

        //      var result = true;

        //      result = await _empBusiness.Delete(Id);
        //      var dataReponse = new
        //      {
        //          success = result,

        //      };
        //      return new JsonResult(dataReponse)
        //      {
        //          StatusCode = StatusCodes.Status200OK

        //      };
        //  }


        //   public async Task<IActionResult> OnPostReactive
        //(int Id = -1)
        //   {

        //       var listEror = new List<object>();

        //       if (Id < 0)
        //       {
        //           var itemError = new
        //           {
        //               name = "id",
        //               Content = "Thiếu thông tin cần xoá"
        //           };
        //           listEror.Add(itemError);

        //       }
        //       if (listEror.Count > 0)
        //       {
        //           return new JsonResult(listEror)
        //           {
        //               StatusCode = StatusCodes.Status400BadRequest
        //           };
        //       }

        //       var result = true;

        //       result = await _empBusiness.Delete(Id, true);
        //       var dataReponse = new
        //       {
        //           success = result,

        //       };
        //       return new JsonResult(dataReponse)
        //       {
        //           StatusCode = StatusCodes.Status200OK

        //       };
        //   }



    }
}
