using System.Text.Json.Serialization;

namespace SortedAPI.Domain
{
    public class ErrorDetail
    {
        [JsonPropertyName("propertyName")]
        public string PropertyName { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}