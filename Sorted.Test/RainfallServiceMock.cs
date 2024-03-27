using Sorted.Domain.Interfaces;
using Sorted.Domain.Rainfall;

namespace Sorted.Test
{
    public class RainfallServiceMock : IRainfallService
    {
        public async Task<IEnumerable<Item>> GetAllReadingsByStationIdAsync(string stationId, int count)
        {
            var items = await GenerateItems(count);

            return stationId == "WithDataStationId" ? items : Enumerable.Empty<Item>();
        }

        private async Task<List<Item>> GenerateItems(int count)
        {
            List<Item> items = [];
            for (int i = 1; i <= count; i++)
            {
                items.Add(new Item() { value = i, dateTime = DateTime.Now });
            }

            await Task.Delay(0);
            return items;
        }
    }
}