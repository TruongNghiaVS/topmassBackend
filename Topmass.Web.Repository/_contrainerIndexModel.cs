namespace Topmass.Web.Repository
{
    public class BaseIndexModel
    {
        public int Status { get; set; }

        public int Id { get; set; }
        public DateTime CreateAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdateAt { get; set; }
        public int UpdatedBy { get; set; }

    }

    public class ArticleIndexModel : BaseIndexModel
    {
        public string? Title { get; set; }

        protected string? CoverImage { get; set; }

        public string CoverFullLink
        {
            get
            {

                if (string.IsNullOrEmpty(CoverImage))
                {
                    return "";
                }
                return "http://42.115.94.180:8584/static/blog/" + CoverImage;
            }
        }

        public string? KeyWord { get; set; }

        public string? Content { get; set; }

        public string? ShortDes { get; set; }

        public string? CategoryName { get; set; }

        public string Linked { get; set; }

        public string? Slug { get; set; }


    }

    public class ArticleShortInfoIndexModel : BaseIndexModel
    {
        public string? Title { get; set; }

        protected string? CoverImage { get; set; }

        public string CoverFullLink
        {
            get
            {

                if (string.IsNullOrEmpty(CoverImage))
                {
                    return "";
                }
                return "http://42.115.94.180:8584/static/blog/" + CoverImage;
            }
        }

        public string? KeyWord { get; set; }

        public string? Content { get; set; }

        public string? ShortDes { get; set; }

        public string? CategoryName { get; set; }

        public string Linked { get; set; }

        public string? Slug { get; set; }


    }

    public class CategoryAritcleIndexModel
    {
        public string Title { get; set; }
        public string? Slug { get; set; }

    }


}
