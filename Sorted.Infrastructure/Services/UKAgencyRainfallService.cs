using Sorted.Domain.Interfaces;
using Sorted.Domain.Rainfall;
using Sorted.Infrastructure.Services.Requester;
using System.Text.Json;

namespace Sorted.Infrastructure.Services
{
    public class UKAgencyRainfallService(IApiRequester apiRequester) : IRainfallService
    {
        public async Task<IEnumerable<Item>> GetAllReadingsByStationIdAsync(string stationId, int count)
        {
            var queryParams = new Dictionary<string, string>()
            {
                { "_sorted", "" },
                { "_limit", count.ToString() }
            };

            // For improvement: Retrieve from cache here, if not available or is no longer valid, send the request

            var body = await apiRequester.GetContentAsStringAsync(HttpMethod.Get,
                $"https://environment.data.gov.uk/flood-monitoring/id/stations/{stationId}/readings",
                [],
                queryParams);

            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var result = !string.IsNullOrEmpty(body) ? JsonSerializer.Deserialize<ServiceResponseReading>(body, option) : null;

            return result != null ? result.items : Enumerable.Empty<Item>();
        }
    }
}
