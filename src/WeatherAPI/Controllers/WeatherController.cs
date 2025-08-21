using Microsoft.AspNetCore.Mvc;

namespace WeatherAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class WeatherController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Pleasant",
        "Warm", "Balmy", "Hot", "Sweltering", "Scorching", "Raining"
    };

    private readonly ILogger<WeatherController> _logger;

    public WeatherController(ILogger<WeatherController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Get weather forecast for the next 5 days
    /// </summary>
    /// <returns>Weather forecast data</returns>
    [HttpGet("forecast")]
    [ProducesResponseType(typeof(object), 200)]
    public IActionResult GetWeatherForecast()
    {
        try
        {
            _logger.LogInformation("Getting weather forecast - Abbott API Demo");
            
            var forecasts = Enumerable.Range(1, 5).Select(index => new
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                TemperatureF = 32 + (int)(Random.Shared.Next(-20, 55) / 0.5556),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToArray();

            return Ok(new
            {
                Status = "Success",
                Message = "Abbott Weather API - Modernization Demo",
                Data = forecasts,
                Timestamp = DateTime.UtcNow,
                Version = "1.0.0",
                Pipeline = "GitHub Actions",
                Environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving weather forecast");
            return StatusCode(500, new { Error = "Internal server error", Message = ex.Message });
        }
    }

    /// <summary>
    /// Get current weather for a specific city
    /// </summary>
    /// <param name="city">City name</param>
    /// <returns>Current weather data</returns>
    [HttpGet("current/{city}")]
    [ProducesResponseType(typeof(object), 200)]
    [ProducesResponseType(400)]
    public IActionResult GetCurrentWeather(string city)
    {
        try
        {
            _logger.LogInformation("Getting current weather for city: {City}", city);

            if (string.IsNullOrEmpty(city))
            {
                return BadRequest(new { Error = "City name is required" });
            }

            var currentWeather = new
            {
                Date = DateOnly.FromDateTime(DateTime.Now),
                TemperatureC = Random.Shared.Next(-20, 55),
                TemperatureF = 32 + (int)(Random.Shared.Next(-20, 55) / 0.5556),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                City = city,
                Country = "Demo"
            };

            return Ok(new
            {
                Status = "Success",
                Message = $"Current weather for {city} - Abbott API Demo",
                Data = currentWeather,
                Timestamp = DateTime.UtcNow,
                Source = "Abbott Modernized API Platform"
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving weather for city: {City}", city);
            return StatusCode(500, new { Error = "Internal server error" });
        }
    }

    /// <summary>
    /// API health check endpoint
    /// </summary>
    [HttpGet("health")]
    [ProducesResponseType(200)]
    public IActionResult HealthCheck()
    {
        return Ok(new
        {
            Status = "Healthy",
            Timestamp = DateTime.UtcNow,
            Service = "Abbott Weather API",
            Version = "1.0.0",
            Environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production",
            Message = "Abbott API modernization platform is operational",
            Uptime = "Demo Mode",
            Pipeline = "GitHub Actions CI/CD"
        });
    }

    /// <summary>
    /// Demo endpoint to show API modernization benefits
    /// </summary>
    [HttpGet("demo-info")]
    [ProducesResponseType(200)]
    public IActionResult GetDemoInfo()
    {
        return Ok(new
        {
            Project = "Abbott API Modernization",
            Platform = "Azure App Service + API Management",
            Pipeline = "GitHub Actions",
            Features = new[]
            {
                "Automated CI/CD Pipeline",
                "Security Scanning (CodeQL)",
                "ServiceNow Integration",
                "Multi-environment Deployment",
                "API Management Gateway",
                "Complete Audit Trail"
            },
            Benefits = new[]
            {
                "Faster Time to Market",
                "Enhanced Security",
                "Automated Governance",
                "Improved Developer Experience",
                "Better Operational Visibility"
            },
            Timestamp = DateTime.UtcNow
        });
    }
}
