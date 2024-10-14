using System.Collections;

namespace Topmass.Admin.Pages.Model.search
{
    public interface IInputBaseRequestSearch
    {
        public int Limit { get; set; }
        public int Page { get; set; }
        public string KeyWord { get; set; }
        public int Status { get; set; }

        public string Token { get; set; }

    }


    public class BaseList
    {
        public int Total { get; set; }
        public IEnumerable? Data { get; set; }
        public BaseList()
        {
            Data = new List<object>();
        }
    }


}
