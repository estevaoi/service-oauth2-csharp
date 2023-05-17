using ServiceOAuth2.business.Data.QueryRequest;
using ServiceOAuth2.business.Data.Request;
using ServiceOAuth2.business.Data.Response;
using ServiceOAuth2.domain.Response;

namespace ServiceOAuth2.business.Services
{
    public interface IUsersService
    {
        Task<(List<UserResponse>, PaginationResponse)> GetUsers(UsersQueryRequest query);
        Task<UserResponse> GetUser(UsersQueryRequest query);
        Task<UserResponse> Insert(UserRequest request);
        Task<UserResponse> Update(UserRequest request, Guid userId);
        Task<bool> Delete(Guid userId);    }
}
