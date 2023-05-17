using System.Text.Json.Serialization;

namespace ServiceOAuth2.data.Models
{
    public class AccessTokensModel : BaseModel
    {
        [JsonPropertyName("access_token_id")] public string AccessTokenId { get; set; }
        [JsonPropertyName("user_id")] public string UserId { get; set; }
        [JsonPropertyName("application_id")] public string ApplicationId { get; set; }
    }
}
