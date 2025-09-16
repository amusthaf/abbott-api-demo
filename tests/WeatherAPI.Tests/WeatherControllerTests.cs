using Microsoft.AspNetCore.Mvc;
using WeatherAPI.Controllers;
using Xunit;

namespace WeatherAPI.Tests;

public class WeatherControllerTests
{
    private readonly WeatherController _controller;

    public WeatherControllerTests()
    {
        _controller = new WeatherController(); // No logger parameter needed now
    }

    [Fact]
    public void Test_ReturnsOkResult()
    {
        // Act
        var result = _controller.Test();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.NotNull(okResult.Value);
        Assert.Equal(200, okResult.StatusCode);
    }

    [Fact]
    public void GetWeatherForecast_ReturnsOkResult()
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
}