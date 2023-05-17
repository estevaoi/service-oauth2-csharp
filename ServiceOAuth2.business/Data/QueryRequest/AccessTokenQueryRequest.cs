namespace ServiceOAuth2.business.Data.QueryRequest
{
    public class AccessTokensQueryRequest : BaseQueryRequest
    {
        public Guid? AccessTokenId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? ApplicationId { get; set; }
    }
}
