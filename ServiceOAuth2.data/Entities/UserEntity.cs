using System.Text.Json.Serialization;

namespace ServiceOAuth2.data.Entities
{
    public class UserEntity
    {
        [JsonPropertyName("user_id")] public Guid UserId { get; set; }
        [JsonPropertyName("username")] public string Username { get; set; }
        [JsonPropertyName("password")] public string Password { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("email")] public string Email { get; set; }
    }
}
