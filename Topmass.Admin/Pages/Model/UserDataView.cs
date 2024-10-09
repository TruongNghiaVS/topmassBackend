namespace Topmass.Admin.Pages.Model
{
    public class UserDataView
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string RoleName
        {
            get
            {
                if (RoleCode == 1)
                    return "Admin";
                return "Không rõ vai trò";
            }
        }
        public int UserId { get; set; }
        public int RoleCode { get; set; }
    }
}
