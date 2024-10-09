namespace Topmass.Core.Repository.IndexModel
{
    public class SearchRepJobRequest
    {

        public int UserId { get; set; }

        public int CampagnId { get; set; }

        public int? Status { get; set; }



        public int Page { get; set; }

        public int Limit { get; set; }


        public SearchRepJobRequest()
        {
            Status = -1;
            Page = 1;
            Limit = 10;

        }

    }

    public class SearchRepJobReponse
    {
        public int Page { get; set; }

        public int Limit { get; set; }

        public int TotalRecord
        {
            get
            {
                if (Data == null || Data.Count < 1)
                {
                    return 0;
                }

                return Data.Count;
            }
        }
        public List<JobItemIndex> Data { get; set; }



        public SearchRepJobReponse()
        {
            Page = 1;
            Limit = 10;

        }

    }

    public class JobItemIndex
    {
        public string Name { get; set; }
        public int? CampaignId { get; set; }
        public string CampaignName { get; set; }

        public int RelId { get; set; }

        public int? Status { get; set; }


        public DateTime CreateAt { get; set; }
        public int Reason { get; set; }

        public string ReasonText { get; set; }

        public string PackageName { get; set; }
        public DateTime AuthorName { get; set; }

        public int ResultCode { get; set; }
        public string ResultText { get; set; }
        public int Id { get; set; }
        public JobItemIndex()
        {
            ReasonText = "Đang hiển thị";
            PackageName = "Đăng tin miễn phí";
            ResultText = "Chờ xác nhận";
            Reason = 1;

        }

    }

    public class SearchRepJobLogView
    {
        public int JobId { get; set; }

        public int CampagnId { get; set; }

        public int Limit { get; set; }

        public int Page { get; set; }

        public int UserId { get; set; }
        public SearchRepJobLogView()
        {


        }

    }

    public class SearchRepJobLogViewReponse
    {
        public int Limit { get; set; }

        public int Page { get; set; }
        public List<JobLogViewIndexModel> Data { get; set; }
    }

}
