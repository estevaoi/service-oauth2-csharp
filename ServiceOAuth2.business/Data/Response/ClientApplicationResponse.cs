namespace ServiceOAuth2.business.Data.Response
{
    public class ClientApplicationResponse
    {
        public Guid ApplicationId { get; set; }
        public string ApplicationName { get; set; }
        public string ClientIdentifier { get; set; }
        public string ClientSecret { get; set; }
        public string RedirectUrls { get; set; }
    }
}
