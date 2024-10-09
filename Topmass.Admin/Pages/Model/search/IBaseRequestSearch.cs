namespace Topmass.Admin.Pages.Model.search
{
    public interface IInputBaseRequestSearch
    {
        public int Limit { get; set; }
        public int Page { get; set; }
        public string KeyWord { get; set; }
        public int Status { get; set; }

    }
}
