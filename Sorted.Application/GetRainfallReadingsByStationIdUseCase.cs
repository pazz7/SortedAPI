using Sorted.Domain.Interfaces;
using Sorted.Domain.Rainfall;

namespace Sorted.Application
{
    public class GetRainfallReadingsByStationIdUseCase(IRainfallService rainfallService)
    {
        public async Task<RainfallReadingResponse> ExecuteAsync(string stationId, int count)
        {
            RainfallReadingResponse response = new() { Readings = [] };

            var items = await rainfallService.GetAllReadingsByStationIdAsync(stationId, count);
            response.Readings = items.Select(i => new RainfallReading() { DateMeasured = i.dateTime, AmountMeasured = i.value }).ToArray();
            return response;
        }
    }
}