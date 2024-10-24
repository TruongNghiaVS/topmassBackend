namespace topmass.Model
{

    public class InputCompanyRequestGetAll
    {
        public string? KeyWord { get; set; }
    }


    public class InputCompanyGetInfo
    {
        public string? Slug { get; set; }

        public int Location { get; set; }

        public string? Keyword { get; set; }

        public InputCompanyGetInfo()
        {
            Location = -1;
        }
    }

}
