using Sorted.Domain.Interfaces;
using Sorted.Domain.Rainfall;

namespace Sorted.Application
{
    public class GetRainfallReadingsByStationIdUseCase(IRainfallService rainfallService)
    {
        public async Task<RainfallReadingResponse> ExecuteAsync(string stationId, int count)
        {
            RainfallReadingResponse response = new() { readings = [] };// new RainfallReading() { amountMeasured = 1, dateMeasured = DateTime.Now.ToString() }] };

            var items = await rainfallService.GetAllReadingsByStationIdAsync(stationId, count);
            response.readings = items.Select(i => new RainfallReading() { dateMeasured = i.dateTime, amountMeasured = i.value }).ToArray();
            return response;
        }
    }
}

