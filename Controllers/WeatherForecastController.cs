using DependencyInjectionSamples.Services;
using DependencyInjectionSamples.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionSamples.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly SecondaryService _secondaryService;
    private readonly TertiaryService _tertiaryService;
    private readonly QuaternaryService _quaternaryService;
    private readonly IService _service;
 
    public WeatherForecastController(
        IService service,
        SecondaryService secondaryService,
        TertiaryService tertiaryService,
        QuaternaryService quaternaryService)
    {
        _service = service;
        _secondaryService = secondaryService;
        _tertiaryService = tertiaryService;
        _quaternaryService = quaternaryService;
    }

    
    [Route("GetServices")]
    [HttpGet(Name = "GetServices")]
    public IActionResult GetServices()
    {
        return Ok(new 
        {
            Id = Guid.NewGuid(),
            PrimaryServiceId = _service.GetGuiId(),
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

    [Route("GetListOfServices")]
    [HttpGet(Name = "GetListOfServices")]
    public IActionResult GetListOfServices()
    {
        
        return Ok(_service.GetType().Name);
    }
}
