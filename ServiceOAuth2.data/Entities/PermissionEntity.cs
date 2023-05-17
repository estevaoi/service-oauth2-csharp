using System.Text.Json.Serialization;

namespace ServiceOAuth2.data.Entities
{
    public class PermissionEntity 
    {
        [JsonPropertyName("permission_id")] public Guid PermissionId { get; set; }
        [JsonPropertyName("user_id")] public Guid UserId { get; set; }
        [JsonPropertyName("user_id")] public string UserNome { get; set; }
        [JsonPropertyName("scope_id")] public Guid ScopeId { get; set; }
        [JsonPropertyName("scope_id")] public string ScopeNome { get; set; }
    }
}
