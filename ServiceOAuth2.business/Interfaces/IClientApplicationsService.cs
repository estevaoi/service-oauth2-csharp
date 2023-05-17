using ServiceOAuth2.business.Data.QueryRequest;
using ServiceOAuth2.business.Data.Request;
using ServiceOAuth2.business.Data.Response;
using ServiceOAuth2.domain.Response;

namespace ServiceOAuth2.business.Services
{
    public interface IClientApplicationsService
    {
        Task<(List<ClientApplicationResponse>, PaginationResponse)> GetClientApplications(ClientApplicationsQueryRequest query);
        Task<ClientApplicationResponse> GetClientApplication(ClientApplicationsQueryRequest query);
        Task<ClientApplicationResponse> Insert(ClientApplicationRequest request);
        Task<ClientApplicationResponse> Update(ClientApplicationRequest request, Guid applicationId);
        Task<bool> Delete(Guid applicationId);
    }
}
