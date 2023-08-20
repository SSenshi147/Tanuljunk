using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tanuljunk.Data;
using Tanuljunk.Models;

namespace Tanuljunk.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherController : ControllerBase
{
    private readonly WeatherContext mainContext;

    public WeatherController(WeatherContext mainContext)
    {
        this.mainContext = mainContext;
    }

    [HttpGet]
    public async Task<List<Weather>> Get()
    {
        return await this.mainContext.WeatherForecasts.ToListAsync(this.HttpContext.RequestAborted);
    }
}
