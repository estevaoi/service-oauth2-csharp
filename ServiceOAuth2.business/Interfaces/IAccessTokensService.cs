using ServiceOAuth2.business.Data.QueryRequest;
using ServiceOAuth2.business.Data.Request;
using ServiceOAuth2.business.Data.Response;
using ServiceOAuth2.domain.Response;

namespace ServiceOAuth2.business.Services
{
    public interface IAccessTokensService
    {
        Task<(List<AccessTokenResponse> Items, PaginationResponse Pagination)> GetAccessTokens(AccessTokensQueryRequest query);
        Task<AccessTokenResponse> GetAccessToken(AccessTokensQueryRequest query);
        Task<AccessTokenResponse> Insert(AccessTokenRequest request);
        Task<AccessTokenResponse> Update(AccessTokenRequest request, Guid accessTokenId);
        Task<bool> Delete(Guid accessTokenId);
    }
}
