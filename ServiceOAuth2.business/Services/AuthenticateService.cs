using Newtonsoft.Json;
using ServiceOAuth2.business.Data.Request;
using ServiceOAuth2.business.Data.Response;
using ServiceOAuth2.business.Interfaces;
using ServiceOAuth2.data.Entities;
using ServiceOAuth2.data.Interfaces;
using ServiceOAuth2.data.Models;
using ServiceOAuth2.data.Repositories;
using System.Security.Claims;

namespace ServiceOAuth2.business.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly IBaseRepository _baseRepository;

        public AuthenticateService(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async  Task<TokenResponse> GetAccessTokenFromClient(AccessTokenFromClientRequest request)
        {
            var applications = await _baseRepository.Get<ClientApplicationEntity, ClientApplicationsModel>(ClientApplicationsRepository.SqlSelect, new ClientApplicationsModel { ClientIdentifier = request.ClientId });

            var application = applications.List.FirstOrDefault();

            if (application == null) throw new Exception($"Not authorized");
            if (!application.ClientSecret.Equals(request.ClientSecret)) throw new Exception($"Not authorized");


            var claim = new Claim[]
                {
                    new Claim("client_id", application.ClientIdentifier.ToString())
                };

            var token = TokenService.GenerateToken(claim);

            return new TokenResponse
            {
                AccessToken = token.AccessToken,
                ExpiresIn = token.ExpiresIn,
                TokenType = "Bearer"
            };
        }

        public async Task<TokenResponse> GetAccessTokenFromUser(AccessTokenFromUserRequest request)
        {
            var accounts = await _baseRepository.Get<UserEntity, UsersModel>(UsersRepository.SqlSelect, new UsersModel { Email = request.Email });

            var account = accounts.List.FirstOrDefault();

            if (account == null) throw new Exception($"Not authorized");
            if (!account.Password.Equals(request.Password)) throw new Exception($"Not authorized");

            var scopeList = request.Scope.Split(" ").ToList();
            var scopeString = JsonConvert.SerializeObject(scopeList);

            var claim = new Claim[]
                {
                    new Claim("client_id", account.UserId.ToString()),
                    new Claim("scope", scopeString)
                };

            var token = TokenService.GenerateToken(claim);

            return new TokenResponse
            {
                AccessToken = token.AccessToken,
                ExpiresIn = token.ExpiresIn,
                TokenType = "Bearer",
                Scope = scopeList
            };            
        }

        public Task<AuthorizationCodeResponse> GetAuthorizationCode(AuthorizationCodeRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<TokenResponse> GetAuthorizationCodeForAccessToken(AuthorizationCodeRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<TokenResponse> RefreshAccessToken(RefreshTokenRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
