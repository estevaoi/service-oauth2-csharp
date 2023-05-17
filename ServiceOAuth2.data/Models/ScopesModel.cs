using System.Text.Json.Serialization;

namespace ServiceOAuth2.data.Models
{
    public class ScopesModel 
    {
        [JsonPropertyName("scope_id")] public string ScopeId { get; set; }
    }
}
