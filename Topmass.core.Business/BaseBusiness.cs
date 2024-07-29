using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Topmass.Core.Model;
using Topmass.Core.Repository;


namespace Topmass.core.Business
{
    public class BaseBusiness<TModel> : IBaseBusiness<TModel> where TModel : BaseModel, new()

    {
        private readonly IBaseRepository<TModel> _repository;


        public BaseBusiness(IBaseRepository<TModel> baseRepository)
        {
            _repository = baseRepository;
        }

        public async Task<bool> AddOrUPdate(TModel itemModel)
        {
            return await _repository.AddOrUPdate(itemModel);
        }

        public async Task<bool> Delete(TModel itemModel)
        {
            return await _repository.Delete(itemModel);
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<IEnumerable<TModel>> GetAllBase()
        {
            return await _repository.GetAllBase();
        }

        public async Task<TModel> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        protected string GenerateToken(UserModel request)
        {
            var issuer = "jobvieclam.com";
            var audience = "nguyentruongnghia";
            var key = Encoding.ASCII.GetBytes
            ("product of vietstargroup");
            var userName = request.UserName;
            var email = request.UserName;
            var fullName = request.UserName;
            var idRequest = request.Id;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                        new Claim("userId", idRequest.ToString()),
                        new Claim("userName", userName),
                        new Claim("role", "Can"),
                        new Claim("fullName", fullName),
                        new Claim("email", email),
                        new Claim("email", email)
                }),
                Expires = DateTime.UtcNow.AddMinutes(60),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials
                (new SymmetricSecurityKey(key),
                SecurityAlgorithms.Aes128CbcHmacSha256)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;

        }
    }
}
