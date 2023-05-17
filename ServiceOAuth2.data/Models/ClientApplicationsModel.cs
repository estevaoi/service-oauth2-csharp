using System.Text.Json.Serialization;

namespace ServiceOAuth2.data.Models
{
    public class ClientApplicationsModel
    {
        [JsonPropertyName("application_id")] public string ApplicationId { get; set; }
    }
}
