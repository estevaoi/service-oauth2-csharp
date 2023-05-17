namespace ServiceOAuth2.data.Dtos
{
    public class ClientApplicationDto
    {
        private Guid _applicationId { get; set; }

        public ClientApplicationDto(Guid applicationId)
        {
            _applicationId = applicationId;
        }

        public Guid ApplicationId
        {
            get { return _applicationId; }
            set { value = _applicationId; }
        }

        public string ApplicationName { get; set; }
        public string ClientIdentifier { get; set; }
        public string ClientSecret { get; set; }
        public string RedirectUrls { get; set; }
    }
}
