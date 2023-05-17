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
    public class ClientApplicationsService : IClientApplicationsService
    {
        private readonly IBaseRepository _baseRepository;

        public ClientApplicationsService(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<(List<ClientApplicationResponse> Items, PaginationResponse Pagination)> GetClientApplications(ClientApplicationsQueryRequest query)
        {
            var response = await _baseRepository.Get<ListResponse<ClientApplicationEntity>, ClientApplicationsModel>(ClientApplicationsRepository.SqlSelect, query.CastX<ClientApplicationsModel>());
            return (response.List.CastX<List<ClientApplicationResponse>>(), response.Pagination);
        }

        public async Task<ClientApplicationResponse> GetClientApplication(ClientApplicationsQueryRequest query)
        {
            var response = await _baseRepository.Get<ListResponse<ClientApplicationEntity>, ClientApplicationsModel>(ClientApplicationsRepository.SqlSelect, query.CastX<ClientApplicationsModel>());

            return response.List.Count == 0
                ? throw new Exception($"None application found.")
                : response.List.FirstOrDefault().CastX<ClientApplicationResponse>();
        }

        public async Task<ClientApplicationResponse> Insert(ClientApplicationRequest request)
        {
            var dto = request.CastX<ClientApplicationDto>();
            dto.ApplicationId = Guid.NewGuid();

            return await _baseRepository.Execute(ClientApplicationsRepository.SqlInsert, dto, ExecuteTypeSqlEnum.INSERT)
                ? await GetClientApplication(new ClientApplicationsQueryRequest { ApplicationId = dto.ApplicationId })
                : throw new Exception($"None registered application.");
        }

        public async Task<ClientApplicationResponse> Update(ClientApplicationRequest request, Guid applicationId)
        {
            var dto = request.CastX<ClientApplicationDto>();
            dto.ApplicationId = applicationId;

            return await _baseRepository.Execute(ClientApplicationsRepository.SqlUpdate, dto, ExecuteTypeSqlEnum.UPDATE)
                ? await GetClientApplication(new ClientApplicationsQueryRequest { ApplicationId = dto.ApplicationId })
                : throw new Exception($"None application changed.");
        }

        public async Task<bool> Delete(Guid applicationId)
        {
            var dto = new ClientApplicationDto(applicationId);

            return await _baseRepository.Execute(ClientApplicationsRepository.SqlDelete, dto, ExecuteTypeSqlEnum.DELETE)
                ? true
                : throw new Exception($"None application deleted.");
        }
    }
}
