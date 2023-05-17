namespace ServiceOAuth2.domain.Response
{
    public class PaginationResponse
    {
        public string Id { get; set; }
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
