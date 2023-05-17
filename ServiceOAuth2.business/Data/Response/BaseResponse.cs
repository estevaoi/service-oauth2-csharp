using ServiceOAuth2.domain.Response;

namespace ServiceOAuth2.business.Data.Response
{
    public class ListResponse<T>
    {
        public T Items { get; set; }
        public PaginationResponse Pagination { get; set; }

    }
}
