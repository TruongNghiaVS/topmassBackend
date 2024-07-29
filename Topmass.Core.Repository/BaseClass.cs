using System.Collections;

namespace Topmass.Core.Repository
{
    public class BaseList
    {
        public int Total { get; set; }
        public IEnumerable? Data { get; set; }
        public BaseList()
        {
            Data = Enumerable.Empty<Object>();
        }
    }

    public class BaseRequest
    {
        public string? Token { get; set; }
        public bool? IsDeleted { get; set; }
        public int? UserId { get; set; }

        public string? UserName { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }
        public string? OrderBy { get; set; }
        public int? Status { get; set; }
        private DateTime? FromTimeAss { get; set; }
        public string? FromText
        {
            get
            {
                if (From.HasValue)
                {
                    return From.Value.ToString("yyyy-MM-dd");
                }
                return "";
            }
        }
        public string? ToText
        {
            get
            {
                if (To.HasValue)
                {
                    return To.Value.ToString("yyyy-MM-dd");
                }
                return "";
            }
        }
        public DateTime? From
        {

            get
            {
                return FromTimeAss;
            }
            set
            {
                if (value.HasValue)
                {
                    FromTimeAss = new DateTime(value.Value.Year, value.Value.Month, value.Value.Day, 0, 0, 0);

                }
                else
                {
                    FromTimeAss = null;
                }

            }
        }


        private DateTime? ToTimeAss { get; set; }
        public DateTime? To
        {
            get
            {
                return ToTimeAss;
            }
            set
            {
                if (value.HasValue)
                {
                    ToTimeAss = new DateTime(value.Value.Year, value.Value.Month, value.Value.Day, 23, 59, 59);

                }
                else
                {
                    ToTimeAss = null;
                }

            }
        }

        public BaseRequest()
        {
            Page = 1;
            FromTimeAss = DateTime.Now.AddMonths(-1);
            ToTimeAss = DateTime.Now;
            Limit = 10;
        }
    }

    public class BaseIndexModel
    {
        public int TotalRecord { get; set; }
        public DateTime CreateAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public int UpdatedBy { get; set; }

        public bool Deleted { get; set; }
        public int Id { get; set; }

        public string AuthorName { get; set; }
    }
}
