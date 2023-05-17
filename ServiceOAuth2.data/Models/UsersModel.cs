using System.Text.Json.Serialization;

namespace ServiceOAuth2.data.Models
{
    public class UsersModel : BaseModel
    {
        [JsonPropertyName("user_id")] public string UserId { get; set; }
        [JsonPropertyName("email")] public string Email { get; set; }
    }
}
