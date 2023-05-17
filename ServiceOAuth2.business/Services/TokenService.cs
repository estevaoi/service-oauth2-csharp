using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ServiceOAuth2.business.Services
{
    public static class TokenService
    {
        private static readonly string _secretJwt = Environment.GetEnvironmentVariable("SECRET_JWT");

        public static (string AccessToken, DateTime ExpiresIn) GenerateToken(Claim[] claim)
        {
            var expireIn = DateTime.UtcNow.AddYears(1);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretJwt);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claim),
                Expires = expireIn,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return (tokenHandler.WriteToken(token), expireIn);
        }
    }
}
