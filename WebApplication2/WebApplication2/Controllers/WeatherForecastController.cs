using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers;
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet("async")]
    public async Task<string> Async()
    {
        await Task.Delay(4000);
        return "done";
    }

    [HttpGet("sleep")]
    public string Sleep()
    {
        Thread.Sleep(4000);
        return "done";
    }
}
