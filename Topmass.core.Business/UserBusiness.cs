using Topmass.Core.Model;
using Topmass.Core.Repository;


namespace Topmass.core.Business
{
    public partial class UserBusiness : BaseBusiness<UserModel>, IUserBuisiness
    {
        private readonly IUserRepository _repository;
        public UserBusiness(IUserRepository userRepository) : base(userRepository)
        {
            _repository = userRepository;
        }
        public async Task<LoginResult> Login(string username, string password)
        {
            var result = new LoginResult();
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                result.Success = false;
                result.Message = "Thiếu tham số, vui lòng cung cấp thông tin tên đăng nhập hoặc mật khẩu";

            }

            var user = new UserModel();
            user.CreateAt = DateTime.Now;
            user.UserName = "NghiaNT15";
            user.Password = "Nhi20222023@";
            var tokenUser = this.GenerateToken(user);
            result.Token = tokenUser;
            result.Success = true;
            result.Message = "Tạo token thành công";
            return result;
        }
    }
}
