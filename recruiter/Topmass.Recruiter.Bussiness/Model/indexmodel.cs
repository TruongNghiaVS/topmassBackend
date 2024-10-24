namespace Topmass.Recruiter.Bussiness.Model
{
    public class CompanyItemDisplay
    {

        protected string CoverLink { get; set; }

        public string CoverFullLink
        {
            get
            {
                if (string.IsNullOrEmpty(CoverLink))
                {
                    return "";
                }
                return "http://42.115.94.180:8584/static/" + CoverLink;
            }

        }

        protected string LogoLink { get; set; }

        public string LogoFullLink
        {
            get
            {
                if (string.IsNullOrEmpty(LogoLink))
                {
                    return "/imgs/logo-work.png";
                }
                return "http://42.115.94.180:8584/static/" + LogoLink;
            }

        }

        public string FullName { get; set; }

        public string Slug { get; set; }

        public int id { get; set; }

        public int FollowCount { get; set; }



    }

}
