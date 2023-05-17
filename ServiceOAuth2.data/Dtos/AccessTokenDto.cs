namespace ServiceOAuth2.data.Dtos
{
    public class AccessTokenDto
    {
        private Guid _accessTokenId { get; set; }

        public AccessTokenDto(Guid accessTokenId)
        {
            _accessTokenId = accessTokenId;
        }

        public Guid AccessTokenId
        {
            get { return _accessTokenId; }
            set { value = _accessTokenId; }
        }

        public Guid UserId { get; set; }
        public Guid ApplicationId { get; set; }
        public string Scope { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ExpiresAt { get; set; }
    }
}
