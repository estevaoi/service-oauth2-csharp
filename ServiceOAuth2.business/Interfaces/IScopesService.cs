using ServiceOAuth2.business.Data.QueryRequest;
using ServiceOAuth2.business.Data.Request;
using ServiceOAuth2.business.Data.Response;
using ServiceOAuth2.domain.Response;

namespace ServiceOAuth2.business.Services
{
    public interface IScopesService
    {
        Task<(List<ScopeResponse> Items, PaginationResponse Pagination)> GetScopes(ScopesQueryRequest query);
        Task<ScopeResponse> GetScope(ScopesQueryRequest query);
        Task<ScopeResponse> Insert(ScopeRequest request);
        Task<ScopeResponse> Update(ScopeRequest request, Guid scopeId);
        Task<bool> Delete(Guid scopeId);
    }
}
