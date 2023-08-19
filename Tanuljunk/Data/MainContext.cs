using Microsoft.EntityFrameworkCore;
using Tanuljunk.Models;

namespace Tanuljunk.Data;

public class MainContext : DbContext
{
    public MainContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<WeatherForecast> WeatherForecasts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var weatherForecasts = new List<WeatherForecast>()
        {
            new WeatherForecast()
            {
                Key = Guid.NewGuid(),
                Date = DateTime.Today,
                Summary = "Meleg van",
                TemperatureC = 32,
            },
            new WeatherForecast()
            {
                Key = Guid.NewGuid(),
                Date = DateTime.Today.AddDays(30),
                Summary = "Hideg van",
                TemperatureC = 3,
            }
        };

        modelBuilder.Entity<WeatherForecast>().HasKey(x => x.Key);
        modelBuilder.Entity<WeatherForecast>().HasData(weatherForecasts);
    }
}
