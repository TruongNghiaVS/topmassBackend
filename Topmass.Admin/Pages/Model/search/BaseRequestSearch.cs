namespace Topmass.Admin.Pages.Model.search
{
    public class BaseInputRequestSearch : IInputBaseRequestSearch
    {
        public int Limit { get; set; }
        public int Page { get; set; }
        public string KeyWord { get; set; }
        public int Status { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public string Token { get; set; }
    }

    public class NTDRequest : BaseInputRequestSearch
    {

    }

}
