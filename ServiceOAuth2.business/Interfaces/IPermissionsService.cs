using ServiceOAuth2.business.Data.QueryRequest;
using ServiceOAuth2.business.Data.Request;
using ServiceOAuth2.business.Data.Response;
using ServiceOAuth2.domain.Response;

namespace ServiceOAuth2.business.Services
{
    public interface IPermissionsService
    {
        Task<(List<PermissionResponse> Items, PaginationResponse Pagination)> GetPermissions(PermissionsQueryRequest query);
        Task<PermissionResponse> GetPermission(PermissionsQueryRequest query);
        Task<PermissionResponse> Insert(PermissionRequest request);
        Task<PermissionResponse> Update(PermissionRequest request, Guid permissionId);
        Task<bool> Delete(Guid permissionId);    }
}
