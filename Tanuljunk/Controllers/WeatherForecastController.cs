using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tanuljunk.Data;
using Tanuljunk.Models;

namespace Tanuljunk.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly MainContext mainContext;

    public WeatherForecastController(MainContext mainContext)
    {
        this.mainContext = mainContext;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<List<WeatherForecast>> Get()
    {
        return await this.mainContext.WeatherForecasts.ToListAsync(this.HttpContext.RequestAborted);
    }
}
