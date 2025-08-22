using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using WeatherAPI.Controllers;
using Xunit;

namespace WeatherAPI.Tests;

public class WeatherControllerTests
{
    private readonly Mock<ILogger<WeatherController>> _mockLogger;
    private readonly WeatherController _controller;

    public WeatherControllerTests()
    {
        _mockLogger = new Mock<ILogger<WeatherController>>();
        _controller = new WeatherController(_mockLogger.Object);
    }

    [Fact]
    public void GetWeatherForecast_ReturnsOkResult_WithForecastData()
    {
        // Act
        var result = _controller.GetWeatherForecast();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.NotNull(okResult.Value);
        Assert.Equal(200, okResult.StatusCode);
    }

    [Fact]
    public void GetCurrentWeather_WithValidCity_ReturnsOkResult()
    {
        // Arrange
        var cityName = "Chicago";

        // Act
        var result = _controller.GetCurrentWeather(cityName);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.NotNull(okResult.Value);
        Assert.Equal(200, okResult.StatusCode);
    }

    [Fact]
    public void GetCurrentWeather_WithEmptyCity_ReturnsBadRequest()
    {
        // Act
        var result = _controller.GetCurrentWeather("");

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public void HealthCheck_ReturnsOkResult()
    {
        // Act
        var result = _controller.HealthCheck();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(200, okResult.StatusCode);
    }

    [Fact]
    public void GetDemoInfo_ReturnsOkResult()
    {
        // Act
        var result = _controller.GetDemoInfo();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(200, okResult.StatusCode);
    }
}