namespace TopMass.Web.Business.Model
{

    public class PageContentResult : PageSeoResult
    {
        public string? Content { get; set; }

    }

    public class PageSeoResult
    {
        public string? TitlePage { get; set; }

        public string? Description { get; set; }
        public string? KeyWord { get; set; }

        public string Image { get; set; }
        public string PageSlug { get; set; }
    }
}
