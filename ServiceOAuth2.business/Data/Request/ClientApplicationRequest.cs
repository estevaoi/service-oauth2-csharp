namespace ServiceOAuth2.business.Data.Request
{
    public class ClientApplicationRequest
    {
        public string ApplicationName { get; set; }
        public string ClientIdentifier { get; set; }
        public string ClientSecret { get; set; }
        public string RedirectUrls { get; set; }
    }
}
