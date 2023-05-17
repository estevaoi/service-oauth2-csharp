namespace ServiceOAuth2.data.Dtos
{
    public class AuthorizationTokenDto
    {
        private Guid _authorizationTokenId { get; set; }

        public AuthorizationTokenDto(Guid authorizationTokenId)
        {
            _authorizationTokenId = authorizationTokenId;
        }

        public Guid AuthorizationTokenId
        {
            get { return _authorizationTokenId; }
            set { value = _authorizationTokenId; }
        }

        public Guid UserId { get; set; }
        public Guid ApplicationId { get; set; }
        public string Scope { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public string AdditionalInfo { get; set; }
    }
}
