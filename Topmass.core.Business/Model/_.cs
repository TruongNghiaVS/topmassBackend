namespace Topmass.core.Business.Model
{
    public class CandidateInfoRequest
    {
        public string Email { get; set; }
        public int UserId { get; set; }

    }

    public class CandidateInfoUpdate
    {
        public string Phone { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName { get; set; }

        public int? UserId { get; set; }

        public int? HandleBy { get; set; }

        public bool? PrivateMode { get; set; }

        public bool? PublicMode { get; set; }

        public string AvatarLink { get; set; }

    }

    public class CandidateInfoResult
    {
        public int? UserId { get; set; }

        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? AvatarLink { get; set; }
        public bool WorkMode { get; set; }
        public bool SearchMode { get; set; }
        public string? UserName { get; set; }

        public int? Status { get; set; }

        public string? StatusText
        {
            get
            {
                return "Hoạt động";
            }
        }
        //public string? FullName { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        public string? AuthenticationLevelText { get; set; }
        public CandidateInfoResult()
        {
            AuthenticationLevelText = "Tài khoản đã xác thực";

        }

    }
}
