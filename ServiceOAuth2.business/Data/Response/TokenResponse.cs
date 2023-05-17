namespace ServiceOAuth2.business.Data.Response
{
    public class TokenResponse
    {
        public string AccessToken { get; set; }
        public DateTime ExpiresIn { get; set; }
        public string TokenType { get; set; }
        public List<string> Scope { get; set; }
    }
}
