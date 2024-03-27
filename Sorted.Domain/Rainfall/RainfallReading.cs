using System.Text.Json.Serialization;

namespace Sorted.Domain.Rainfall
{
    /// <summary>
    /// Details of a rainfall reading 
    /// </summary>
    public class RainfallReading
    {
        [JsonPropertyName("dateMeasured")]
        public DateTime DateMeasured { get; set; }

        [JsonPropertyName("amountMeasured")]
        public decimal AmountMeasured { get; set; }
    }
}