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
    public class AuthorizationTokensService : IAuthorizationTokensService
    {
        private readonly IBaseRepository _baseRepository;

        public AuthorizationTokensService(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<(List<AuthorizationTokenResponse> Items, PaginationResponse Pagination)> GetAuthorizationTokens(AuthorizationTokensQueryRequest query)
        {
            var response = await _baseRepository.Get<AuthorizationTokenEntity, AuthorizationTokensModel>(AuthorizationTokensRepository.SqlSelect, query.CastX<AuthorizationTokensModel>());
            return (response.List.CastX<List<AuthorizationTokenResponse>>(), response.Pagination);
        }

        public async Task<AuthorizationTokenResponse> GetAuthorizationToken(AuthorizationTokensQueryRequest query)
        {
            var response = await _baseRepository.Get<AuthorizationTokenEntity, AuthorizationTokensModel>(AuthorizationTokensRepository.SqlSelect, query.CastX<AuthorizationTokensModel>());

            return response.List.Count == 0
                ? throw new Exception($"None authorization token found.")
                : response.List.FirstOrDefault().CastX<AuthorizationTokenResponse>();
        }

        public async Task<AuthorizationTokenResponse> Insert(AuthorizationTokenRequest request)
        {
            var dto = request.CastX<AuthorizationTokenDto>();
            dto.AuthorizationTokenId = Guid.NewGuid();

            return await _baseRepository.Execute(AuthorizationTokensRepository.SqlInsert, dto, ExecuteTypeSqlEnum.INSERT)
                ? await GetAuthorizationToken(new AuthorizationTokensQueryRequest { AuthorizationTokenId = dto.AuthorizationTokenId })
                : throw new Exception($"None registered authorization token.");
        }

        public async Task<AuthorizationTokenResponse> Update(AuthorizationTokenRequest request, Guid authorizationTokenId)
        {
            var dto = request.CastX<AuthorizationTokenDto>();
            dto.AuthorizationTokenId = authorizationTokenId;

            return await _baseRepository.Execute(AuthorizationTokensRepository.SqlUpdate, dto, ExecuteTypeSqlEnum.UPDATE)
                ? await GetAuthorizationToken(new AuthorizationTokensQueryRequest { AuthorizationTokenId = dto.AuthorizationTokenId })
                : throw new Exception($"None authorization token changed.");
        }

        public async Task<bool> Delete(Guid authorizationTokenId)
        {
            var dto = new AuthorizationTokenDto(authorizationTokenId);

            return await _baseRepository.Execute(AuthorizationTokensRepository.SqlDelete, dto, ExecuteTypeSqlEnum.DELETE)
                ? true
                : throw new Exception($"None authorization token deleted.");
        }
    }
}
