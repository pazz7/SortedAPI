using Microsoft.AspNetCore.Mvc;
using Sorted.Application;
using Sorted.Domain.Interfaces;
using Sorted.Domain.Rainfall;
using SortedAPI.Controllers;

namespace Sorted.Test
{
    public class RainfallControllerTest
    {
        private readonly RainfallController _controller;
        private readonly IRainfallService _service;

        public RainfallControllerTest()
        {
            _service = new RainfallServiceMock();
            _controller = new RainfallController(new GetRainfallReadingsByStationIdUseCase(_service));            
        }

        [Fact]
        public async void GetByStationId_WhenCalled_ResturnsStationReadings()
        {
            // Act
            var okResult = await _controller.GetRainfall("WithDataStationId", 10) as OkObjectResult;

            // Assert
            var response = Assert.IsType<RainfallReadingResponse>(okResult?.Value);
            Assert.Equal(10, response.readings.Length);
        }

        [Fact]
        public async void GetByStationId_WhenCalled_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = await _controller.GetRainfall("WithoutDataStationId", 10) as ObjectResult;

            // Assert
            Assert.IsType<NotFoundObjectResult>(notFoundResult);
        }
    }
}