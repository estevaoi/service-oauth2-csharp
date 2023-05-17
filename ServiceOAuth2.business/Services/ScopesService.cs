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
    public class ScopesService : IScopesService
    {
        private readonly IBaseRepository _baseRepository;

        public ScopesService(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<(List<ScopeResponse> Items, PaginationResponse Pagination)> GetScopes(ScopesQueryRequest query)
        {
            var response = await _baseRepository.Get<ScopeEntity, ScopesModel>(ScopesRepository.SqlSelect, query.CastX<ScopesModel>());
            return (response.List.CastX<List<ScopeResponse>>(), response.Pagination);
        }

        public async Task<ScopeResponse> GetScope(ScopesQueryRequest query)
        {
            var response = await _baseRepository.Get<ScopeEntity, ScopesModel>(ScopesRepository.SqlSelect, query.CastX<ScopesModel>());

            return response.List.Count == 0
                ? throw new Exception($"None scope found.")
                : response.List.FirstOrDefault().CastX<ScopeResponse>();
        }

        public async Task<ScopeResponse> Insert(ScopeRequest request)
        {
            var dto = request.CastX<ScopeDto>();
            dto.ScopeId = Guid.NewGuid();

            return await _baseRepository.Execute(ScopesRepository.SqlInsert, dto, ExecuteTypeSqlEnum.INSERT)
                ? await GetScope(new ScopesQueryRequest { ScopeId = dto.ScopeId })
                : throw new Exception($"None registered scope.");
        }

        public async Task<ScopeResponse> Update(ScopeRequest request, Guid scopeId)
        {
            var dto = request.CastX<ScopeDto>();
            dto.ScopeId = scopeId;

            return await _baseRepository.Execute(ScopesRepository.SqlUpdate, dto, ExecuteTypeSqlEnum.UPDATE)
                ? await GetScope(new ScopesQueryRequest { ScopeId = dto.ScopeId })
                : throw new Exception($"None scope changed.");
        }

        public async Task<bool> Delete(Guid scopeId)
        {
            var dto = new ScopeDto(scopeId);

            return await _baseRepository.Execute(ScopesRepository.SqlDelete, dto, ExecuteTypeSqlEnum.DELETE)
                ? true
                : throw new Exception($"None scope deleted.");
        }
    }
}
