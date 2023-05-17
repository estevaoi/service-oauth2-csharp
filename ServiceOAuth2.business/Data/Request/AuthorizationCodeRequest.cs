namespace ServiceOAuth2.business.Data.Request
{
    public class AuthorizationCodeRequest
    {

        public string ClientId { get; set; }
        public string RedirectUri { get; set; }
        public string State { get; set; }
        public string Scope { get; set; }
    }
}
