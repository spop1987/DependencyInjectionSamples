using DependencyInjectionSamples.Services;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionSamples.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly PrimaryService _primaryService;
    private readonly SecondaryService _secondaryService;
    private readonly TertiaryService _tertiaryService;
    private readonly QuaternaryService _quaternaryService;
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(
        ILogger<WeatherForecastController> logger,
        PrimaryService primaryService,
        SecondaryService secondaryService,
        TertiaryService tertiaryService,
        QuaternaryService quaternaryService)
    {
        _logger = logger;
        _primaryService = primaryService;
        _secondaryService = secondaryService;
        _tertiaryService = tertiaryService;
        _quaternaryService = quaternaryService;
    }

    [Route("GetWeatherForecast")]
    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [Route("GetServices")]
    [HttpGet(Name = "GetServices")]
    public IActionResult GetServices()
    {
        return Ok(new 
        {
            Id = Guid.NewGuid(),
            PrimaryServiceId = _primaryService.Id,
            PrimaryServiceCount = PrimaryService.CreationCount,
            SecondaryService = new {
                Id = _secondaryService.Id,
                PrimaryServiceId = _secondaryService.PrimaryServiceId,
                PrimaryServiceCount = PrimaryService.CreationCount,
                SecondaryServiceCount = SecondaryService.CreationCount
            },
            TertiaryService = new {
                Id = _tertiaryService.Id,
                PrimaryServiceId = _tertiaryService.PrimaryServiceId,
                SecondaryServiceId = _tertiaryService.SecondaryServiceId,
                SecondaryServiceNewInstance = _tertiaryService.SecondaryServiceNewInstanceId,
                PrimaryServiceCount = PrimaryService.CreationCount,
                SecondaryServiceCount = SecondaryService.CreationCount,
                TertiaryServiceCount = TertiaryService.CreationCount
            },
            QuaternaryService = new {
                Id = _quaternaryService.Id,
                TertiaryServiceId = _quaternaryService.TertiaryServiceId,
                TertiaryServiceCount = TertiaryService.CreationCount,
                QuaternaryServiceCount = QuaternaryService.CreationCount
            }
        });
    }
}
