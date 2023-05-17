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
    public class PermissionsService : IPermissionsService
    {
        private readonly IBaseRepository _baseRepository;

        public PermissionsService(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<(List<PermissionResponse> Items, PaginationResponse Pagination)> GetPermissions(PermissionsQueryRequest query)
        {
            var response = await _baseRepository.Get<PermissionEntity, PermissionsModel>(PermissionsRepository.SqlSelect, query.CastX<PermissionsModel>());
            return (response.List.CastX<List<PermissionResponse>>(), response.Pagination);
        }

        public async Task<PermissionResponse> GetPermission(PermissionsQueryRequest query)
        {
            var response = await _baseRepository.Get<PermissionEntity, PermissionsModel>(PermissionsRepository.SqlSelect, query.CastX<PermissionsModel>());

            return response.List.Count == 0
                ? throw new Exception($"None permission found.")
                : response.List.FirstOrDefault().CastX<PermissionResponse>();
        }

        public async Task<PermissionResponse> Insert(PermissionRequest request)
        {
            var dto = request.CastX<PermissionDto>();
            dto.PermissionId = Guid.NewGuid();

            return await _baseRepository.Execute(PermissionsRepository.SqlInsert, dto, ExecuteTypeSqlEnum.INSERT)
                ? await GetPermission(new PermissionsQueryRequest { PermissionId = dto.PermissionId })
                : throw new Exception($"None registered permission.");
        }

        public async Task<PermissionResponse> Update(PermissionRequest request, Guid permissionId)
        {
            var dto = request.CastX<PermissionDto>();
            dto.PermissionId = permissionId;

            return await _baseRepository.Execute(PermissionsRepository.SqlUpdate, dto, ExecuteTypeSqlEnum.UPDATE)
                ? await GetPermission(new PermissionsQueryRequest { PermissionId = dto.PermissionId })
                : throw new Exception($"None permission changed.");
        }

        public async Task<bool> Delete(Guid permissionId)
        {
            var dto = new PermissionDto(permissionId);

            return await _baseRepository.Execute(PermissionsRepository.SqlDelete, dto, ExecuteTypeSqlEnum.DELETE)
                ? true
                : throw new Exception($"None permission deleted.");
        }
    }
}
