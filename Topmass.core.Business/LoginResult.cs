namespace Topmass.core.Business
{

    public class BaseResult
    {
        public BaseResult() { }
        public bool Success { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }
    }
    public class LoginResult : BaseResult
    {
        public string Token { get; set; }
        public LoginResult()
        {


        }
    }
}
