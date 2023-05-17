using System.Text.Json.Serialization;

namespace ServiceOAuth2.data.Models
{
    public class PermissionsModel : BaseModel
    {
        [JsonPropertyName("permission_id")] public string PermissionId { get; set; }
        [JsonPropertyName("user_id")] public string UserId { get; set; }
        [JsonPropertyName("scope_id")] public string ScopeId { get; set; }
    }
}
