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
    public class AccessTokensService : IAccessTokensService
    {
        private readonly IBaseRepository _baseRepository;

        public AccessTokensService(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<(List<AccessTokenResponse> Items, PaginationResponse Pagination)> GetAccessTokens(AccessTokensQueryRequest query)
        {
            var response = await _baseRepository.Get<ListResponse<AccessTokenEntity>, AccessTokensModel>(AccessTokensRepository.SqlSelect, query.CastX<AccessTokensModel>());
            return (response.List.CastX<List<AccessTokenResponse>>(), response.Pagination);
        }

        public async Task<AccessTokenResponse> GetAccessToken(AccessTokensQueryRequest query)
        {
            var response = await _baseRepository.Get<ListResponse<AccessTokenEntity>, AccessTokensModel>(AccessTokensRepository.SqlSelect, query.CastX<AccessTokensModel>());

            return response.List.Count == 0
                ? throw new Exception($"None access token found.")
                : response.List.FirstOrDefault().CastX<AccessTokenResponse>();
        }

        public async Task<AccessTokenResponse> Insert(AccessTokenRequest request)
        {
            var dto = request.CastX<AccessTokenDto>();
            dto.AccessTokenId = Guid.NewGuid();

            return await _baseRepository.Execute(AccessTokensRepository.SqlInsert, dto, ExecuteTypeSqlEnum.INSERT)
                ? await GetAccessToken(new AccessTokensQueryRequest { AccessTokenId = dto.AccessTokenId })
                : throw new Exception($"None registered access token.");
        }

        public async Task<AccessTokenResponse> Update(AccessTokenRequest request, Guid accessTokenId)
        {
            var dto = request.CastX<AccessTokenDto>();
            dto.AccessTokenId = accessTokenId;

            return await _baseRepository.Execute(AccessTokensRepository.SqlUpdate, dto, ExecuteTypeSqlEnum.UPDATE)
                ? await GetAccessToken(new AccessTokensQueryRequest { AccessTokenId = dto.AccessTokenId })
                : throw new Exception($"None access token changed.");
        }

        public async Task<bool> Delete(Guid accessTokenId)
        {
            var dto = new AccessTokenDto(accessTokenId);

            return await _baseRepository.Execute(AccessTokensRepository.SqlDelete, dto, ExecuteTypeSqlEnum.DELETE)
                ? true
                : throw new Exception($"None access token deleted.");
        }
    }
}
