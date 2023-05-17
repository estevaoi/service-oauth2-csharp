using ServiceOAuth2.business.Data.Request;
using ServiceOAuth2.business.Data.Response;

namespace ServiceOAuth2.business.Interfaces
{
    public interface IAuthenticateService
    {
        Task<AuthorizationCodeResponse> GetAuthorizationCode(AuthorizationCodeRequest request);
        Task<TokenResponse> GetAuthorizationCodeForAccessToken(AuthorizationCodeRequest request);
        Task<TokenResponse> GetAccessTokenFromUser(AccessTokenFromUserRequest request);
        Task<TokenResponse> GetAccessTokenFromClient(AccessTokenFromClientRequest request);
        Task<TokenResponse> RefreshAccessToken(RefreshTokenRequest request);
    }
}
