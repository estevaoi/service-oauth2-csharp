namespace ServiceOAuth2.business.Data.QueryRequest
{
    public class BaseQueryRequest
    {
        public int Page { get; set; } = 1;
        public string OrderBy { get; set; } = "";
        public int ItemsPerPage { get; set; } = 10;
    }
}
