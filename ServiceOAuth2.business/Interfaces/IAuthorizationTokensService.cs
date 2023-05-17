using ServiceOAuth2.business.Data.QueryRequest;
using ServiceOAuth2.business.Data.Request;
using ServiceOAuth2.business.Data.Response;
using ServiceOAuth2.domain.Response;

namespace ServiceOAuth2.business.Services
{
    public interface IAuthorizationTokensService
    {
        Task<(List<AuthorizationTokenResponse> Items, PaginationResponse Pagination)> GetAuthorizationTokens(AuthorizationTokensQueryRequest query);
        Task<AuthorizationTokenResponse> GetAuthorizationToken(AuthorizationTokensQueryRequest query);
        Task<AuthorizationTokenResponse> Insert(AuthorizationTokenRequest request);
        Task<AuthorizationTokenResponse> Update(AuthorizationTokenRequest request, Guid authorizationId);
        Task<bool> Delete(Guid authorizationId);
    }
}
