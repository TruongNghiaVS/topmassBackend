namespace Topmass.Admin.Pages.Model.search
{
    public class BaseInputRequestSearch : IInputBaseRequestSearch
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int Limit { get; set; }

        public int Page { get; set; }

        public string Status { get; set; }
        public string Token { get; set; }

        public string FromText
        {
            get
            {

                return From.ToString("yyyy-MM-dd");

            }
        }
        public string ToText
        {
            get
            {

                return To.ToString("yyyy-MM-dd");
            }
        }
        public BaseInputRequestSearch()
        {
            Limit = 20;
            Page = 1;
            From = DateTime.Now.AddDays(-30);
            To = DateTime.Now.AddDays(1);

        }
    }

    public class NTDRequest : BaseInputRequestSearch
    {


        public string AuthenLevel
        {
            get; set;
        }

        public NTDRequest()
        {
            AuthenLevel = "-1";
        }
    }

}
