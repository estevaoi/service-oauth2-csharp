using System.Text.Json.Serialization;

namespace ServiceOAuth2.data.Entities
{
    public class AccessTokenEntity
    {
        [JsonPropertyName("access_token_id")] public Guid AccessTokenId { get; set; }
        [JsonPropertyName("user_id")] public Guid UserId { get; set; }
        [JsonPropertyName("user_id")] public string UserNome { get; set; }
        [JsonPropertyName("application_id")] public Guid ApplicationId { get; set; }
        [JsonPropertyName("application_id")] public string ApplicationNome { get; set; }
        [JsonPropertyName("scope")] public string Scope { get; set; }
        [JsonPropertyName("created_at")] public DateTime? CreatedAt { get; set; }
        [JsonPropertyName("expires_at")] public DateTime? ExpiresAt { get; set; }
    }
}
