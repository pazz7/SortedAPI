using Microsoft.AspNetCore.Mvc;
using Sorted.Application;
using Sorted.Domain.Rainfall;
using SortedAPI.Domain;
using System.ComponentModel.DataAnnotations;

namespace SortedAPI.Controllers
{
    /// <summary>
    /// An API which provides rainfall reading data
    /// </summary>
    /// <param name="getRainfallReadingsByStationIdUseCase"></param>
    [Route("/rainfall")]
    [ApiController]
    public class RainfallController(GetRainfallReadingsByStationIdUseCase getRainfallReadingsByStationIdUseCase) : ControllerBase
    {
        /// <summary>
        /// Get rainfall readings by station Id 
        /// </summary>
        /// <description>
        /// Retrieve the latest readings for the specified stationId
        /// </description>
        /// <param name="stationId">The id of the reading station</param>
        /// <param name="count">The number of readings to return</param>
        /// <returns>A list of rainfall readings successfully retrieved</returns>
        /// <response code = "200">A list of rainfall readings successfully retrieved</response>
        /// <response code = "400">Invalid request</response>
        /// <response code = "404"> No readings found for the specified stationId</response>
        [HttpGet("id/{stationId}/readings")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RainfallReadingResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Error))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error))]
        public async Task<IActionResult> GetRainfall(string stationId, [Range(1, 100)] int count = 10)
        {
            //logger.LogInformation($"Get top {count} sorted rainfall readings of Station {stationId}");
            RainfallReadingResponse response = await getRainfallReadingsByStationIdUseCase.ExecuteAsync(stationId, count);
            if(response == null || response.Readings.Length == 0) 
                return NotFound(new Error() { Message = "No readings found for the specified stationId" });

            return Ok(response);
        }
    }
}