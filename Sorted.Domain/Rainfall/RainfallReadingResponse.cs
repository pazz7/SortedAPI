using System.Text.Json.Serialization;

namespace Sorted.Domain.Rainfall
{
    /// <summary>
    ///  A list of rainfall readings successfully retrieved
    /// </summary>
    public class RainfallReadingResponse
    {
        [JsonPropertyName("readings")]
        public RainfallReading[] Readings { get; set; }
    }
}
