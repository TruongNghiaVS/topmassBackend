namespace Topmass.Admin.Business.Model
{

    public class SearchNTDReponse
    {

        public List<NTDItemDisplay> Data { get; set; }

        public SearchNTDReponse()
        {
            Data = new List<NTDItemDisplay>();
        }
    }

}
