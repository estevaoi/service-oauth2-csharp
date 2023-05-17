namespace ServiceOAuth2.business.Data.QueryRequest
{
    public class AuthorizationTokensQueryRequest : BaseQueryRequest
    {
        public Guid? AuthorizationTokenId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? ApplicationId { get; set; }
    }
}
