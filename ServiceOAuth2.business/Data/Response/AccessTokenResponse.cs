namespace ServiceOAuth2.business.Data.Response
{
    public class AccessTokenResponse
    {
        public Guid AccessTokenId { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public Guid ApplicationId { get; set; }
        public string ApplicationNome { get; set; }
        public string Scope { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ExpiresAt { get; set; }
    }
}
