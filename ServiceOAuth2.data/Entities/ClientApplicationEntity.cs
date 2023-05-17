using System.Text.Json.Serialization;

namespace ServiceOAuth2.data.Entities
{
    public class ClientApplicationEntity 
    {
        [JsonPropertyName("application_id")] public Guid ApplicationId { get; set; }
        [JsonPropertyName("application_name")] public string ApplicationName { get; set; }
        [JsonPropertyName("client_identifier")] public string ClientIdentifier { get; set; }
        [JsonPropertyName("client_secret")] public string ClientSecret { get; set; }
        [JsonPropertyName("redirect_urls")] public string RedirectUrls { get; set; }
    }
}
