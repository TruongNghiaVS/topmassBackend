namespace Topmass.Admin.Business
{
    public class SearchNTDRequest : BaseRequest
    {

    }

    public class BaseRequest
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int Limit { get; set; }

        public int Page { get; set; }

        public string Token { get; set; }

        public int Status { get; set; }

        public int AuthenLevel { get; set; }

        public BaseRequest()
        {
            Limit = 20;
            Page = 1;
            Status = -1;
            From = DateTime.Now.AddDays(-30);
            To = DateTime.Now.AddDays(1);
            AuthenLevel = -1;
        }
    }
}
