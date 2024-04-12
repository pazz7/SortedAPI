using SortedAPI.Domain;
using System.Text.Json.Serialization;

namespace Sorted.Domain
{
    public class ErrorResponse
    {
        [JsonPropertyName("error")]
        public Error Error { get; set; }
    }
}
