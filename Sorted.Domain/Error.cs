using System.Text.Json.Serialization;

namespace SortedAPI.Domain
{
    public class Error
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("details")]
        public ErrorDetail[] Details { get; set; }
    }
}