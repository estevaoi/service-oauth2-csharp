namespace ServiceOAuth2.data.Models
{
    public class BaseModel
    {
        public int Page { get; set; } = 1;
        public string OrderBy { get; set; } = "";
        public int ItemsPerPage { get; set; } = 10;

        public string QueryLike(string texto)
        {
            return texto != null ? $"%{texto}%" : null;
        }
    }
}
