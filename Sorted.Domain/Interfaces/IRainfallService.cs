using Sorted.Domain.Rainfall;

namespace Sorted.Domain.Interfaces
{
    public interface IRainfallService
    {
        Task<IEnumerable<Item>> GetAllReadingsByStationIdAsync(string stationId, int count);
    }
}
