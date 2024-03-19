using Microsoft.AspNetCore.Mvc;
using Sorted.Application;
using Sorted.Domain.Rainfall;

namespace SortedAPI.Controllers
{
    [Route("api/rainfall")]
    [ApiController]
    public class RainfallController(
        GetRainfallReadingsByStationIdUseCase getRainfallReadingsByStationIdUseCase,
        ILogger<RainfallController> logger) : ControllerBase
    {
        [HttpGet("id/{stationId}/readings")]
        public async Task<ActionResult<RainfallReadingResponse>> GetRainfall(string stationId, int count = 10)
        {
            RainfallReadingResponse response = await getRainfallReadingsByStationIdUseCase.ExecuteAsync(stationId, count);
            return Ok(response);
        }
    }
}
