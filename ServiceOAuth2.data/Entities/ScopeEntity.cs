using System.Text.Json.Serialization;

namespace ServiceOAuth2.data.Entities
{
    public class ScopeEntity 
    {
        [JsonPropertyName("scope_id")] public Guid ScopeId { get; set; }
        [JsonPropertyName("scope_name")] public string ScopeName { get; set; }
        [JsonPropertyName("description")] public string Description { get; set; }
    }
}
