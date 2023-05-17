using ServiceOAuth2.domain.Enums;
using ServiceOAuth2.domain.Response;
using System.Runtime.CompilerServices;

namespace ServiceOAuth2.data.Interfaces
{
    public interface IBaseRepository
    {
        Task<bool> Execute<T>(string sql, T dto, ExecuteTypeSqlEnum tipo, [CallerFilePath] string sourceFilePath = "");
        Task<(List<E> List, PaginationResponse Pagination)> Get<E, M>(string sql, M query, [CallerFilePath] string sourceFilePath = "");
    }
}
