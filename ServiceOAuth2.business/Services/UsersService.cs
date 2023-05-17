using ServiceOAuth2.business.Data.QueryRequest;
using ServiceOAuth2.business.Data.Request;
using ServiceOAuth2.business.Data.Response;
using ServiceOAuth2.comum.Extensions;
using ServiceOAuth2.data.Dtos;
using ServiceOAuth2.data.Entities;
using ServiceOAuth2.data.Interfaces;
using ServiceOAuth2.data.Models;
using ServiceOAuth2.data.Repositories;
using ServiceOAuth2.domain.Enums;
using ServiceOAuth2.domain.Response;

namespace ServiceOAuth2.business.Services
{
    public class UsersService : IUsersService
    {
        private readonly IBaseRepository _baseRepository;

        public UsersService(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<(List<UserResponse> Items, PaginationResponse Pagination)> GetUsers(UsersQueryRequest query)
        {
            var response = await _baseRepository.Get<ListResponse<UserEntity>, UsersModel>(UsersRepository.SqlSelect, query.CastX<UsersModel>());
            return (response.List.CastX<List<UserResponse>>(), response.Pagination);
        }

        public async Task<UserResponse> GetUser(UsersQueryRequest query)
        {
            var response = await _baseRepository.Get<ListResponse<UserEntity>, UsersModel>(UsersRepository.SqlSelect, query.CastX<UsersModel>());

            return response.List.Count == 0
                ? throw new Exception($"None user found.")
                : response.List.FirstOrDefault().CastX<UserResponse>();
        }

        public async Task<UserResponse> Insert(UserRequest request)
        {
            var dto = request.CastX<UserDto>();
            dto.UserId = Guid.NewGuid();

            return await _baseRepository.Execute(UsersRepository.SqlInsert, dto, ExecuteTypeSqlEnum.INSERT)
                ? await GetUser(new UsersQueryRequest { UserId = dto.UserId })
                : throw new Exception($"None registered user.");
        }

        public async Task<UserResponse> Update(UserRequest request, Guid userId)
        {
            var dto = request.CastX<UserDto>();
            dto.UserId = userId;

            return await _baseRepository.Execute(UsersRepository.SqlUpdate, dto, ExecuteTypeSqlEnum.UPDATE)
                ? await GetUser(new UsersQueryRequest { UserId = dto.UserId })
                : throw new Exception($"None user changed.");
        }

        public async Task<bool> Delete(Guid userId)
        {
            var dto = new UserDto(userId);

            return await _baseRepository.Execute(UsersRepository.SqlDelete, dto, ExecuteTypeSqlEnum.DELETE)
                ? true
                : throw new Exception($"None user deleted.");
        }
    }
}
