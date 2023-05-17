using System.Text.Json.Serialization;

namespace ServiceOAuth2.data.Entities
{
    public class AuthorizationTokenEntity
    {
        [JsonPropertyName("authorization_token_id")] public Guid AuthorizationTokenId { get; set; }
        [JsonPropertyName("user_id")] public Guid UserId { get; set; }
        [JsonPropertyName("user_id")] public string UserName { get; set; }
        [JsonPropertyName("application_id")] public Guid ApplicationId { get; set; }
        [JsonPropertyName("application_id")] public string ApplicationNome { get; set; }
        [JsonPropertyName("scope")] public string Scope { get; set; }
        [JsonPropertyName("created_at")] public DateTime? CreatedAt { get; set; }
        [JsonPropertyName("expires_at")] public DateTime? ExpiresAt { get; set; }
        [JsonPropertyName("additional_info")] public string AdditionalInfo { get; set; }
    }
}
