using Microsoft.AspNetCore.Mvc;

namespace WeatherAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherController : ControllerBase
{
    [HttpGet("test")]
    public IActionResult Test()
    {
        return Ok(new { Message = "Test endpoint works", Timestamp = DateTime.UtcNow });
    }
    
    [HttpGet("forecast")]
    public IActionResult GetWeatherForecast()
    {
        return Ok(new { Message = "Forecast works", Data = "Simple response" });
    }
    
    [HttpGet("current/{city}")]
    public IActionResult GetCurrentWeather(string city)
    {
        return Ok(new { City = city, Message = "Current weather works" });
    }
}